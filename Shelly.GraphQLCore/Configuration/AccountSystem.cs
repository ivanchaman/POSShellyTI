using Microsoft.Extensions.Configuration;
using Shelly.Abstractions.Settings;
using Shelly.ProviderData.Repository.SP;

namespace Shelly.GraphQLCore.Configuration
{
     public class AccountSystem : BaseSystem
     {
          protected Users User { get; set; }
          protected UsersAccounts Accounts{ get; set; }


          public AccountSystem(DataAccess dataAccess, ICacheContext cache, IConfiguration section) : base(dataAccess, cache)
          {
               LoadProperties();
               JsonLoadSettings(section);
          }
          public AccountSystem(DataAccess dataAccess, ICacheContext cache) : base(dataAccess, cache)
          {
               LoadProperties();
          }
          public AccountSystem(BaseSystem system) : base((DataAccess)system.Connection, system.Cache)
          {
               LoadProperties();
               this.Session = system.Session;

          }
          private void LoadProperties()
          {
               User = new Users(this);
               Accounts = new UsersAccounts(this);     
          }
          private void JsonLoadSettings(IConfiguration section)
          {
               section.GetSection(Shelly.Abstractions.Settings.Local.SectionKey).Bind(LocalSettings);
               section.GetSection(Shelly.Abstractions.Settings.Options.DataAccess.SectionKey).Bind(LocalSettings.DataAccess);
               section.GetSection(Shelly.Abstractions.Settings.Options.BlobStorages.SectionKey).Bind(LocalSettings.BlobStorages);
               section.GetSection(Shelly.Abstractions.Settings.Options.Cache.SectionKey).Bind(LocalSettings.Cache);
               section.GetSection(Shelly.Abstractions.Settings.Options.HttpServices.SectionKey).Bind(LocalSettings.HttpServices);
               section.GetSection(Shelly.Abstractions.Settings.Options.Email.SectionKey).Bind(LocalSettings.Email);
          }
          public void LogIn(long userNumber, long company)
          {
               using (ConnectionHandler coneccion = new ConnectionHandler((DataAccess)Connection))
               {
                    LoadUser(userNumber);
                    LoadCompanyInfo(company);
                    LoadUserWalletInfo(company);
                    LoadInfoUserSession();
                    LoadInfoSecurityTwofactor();
                    LoadTermsAndCoditions();
               }
          }
          public void LogIn(string user, string password, long company)
          {
               using (ConnectionHandler coneccion = new ConnectionHandler((DataAccess)Connection))
               {
                    LoadUser(user);
                    DeletePendingRemoveUser();
                    ValidateInfoUser(password);
                    LoadCompanyInfo(company);
                    LoadUserWalletInfo(company);
                    LoadInfoUserSession();
                    LoadInfoSecurityTwofactor();
                    LoadTermsAndCoditions();
                    InsertLogDataLogin(true);
               }
          }
          private void DeletePendingRemoveUser()
          {
               if (User.Status != (int)UserStatusType.DELETEPENDING)
                    return;
               User.Load(User.Id);
               User.Status = (int)UserStatusType.ACTIVE;
               User.Save();
               User.DeleteRegisterDeleteUsers();
               User.Load(User.Id);
          }
          private void LoadInfoSecurityTwofactor()
          {
               UsersSecurityCollection securities = new UsersSecurityCollection(this);
               HashSet<UsersSecurity> list = securities.GetCollection($"UserNumber = {User.Id} and status in ({(int)UserStatusSecurityType.ACTIVE},{(int)UserStatusSecurityType.PRIMARY})", false, "status desc");
               HasTwofactor = false;
               if (list.Count == 0)
                    return;
               HasTwofactor = true;
               PrimaryTwoFactor = list.ElementAt(0).Id;
          }
          private void ValidateInfoUser(string password)
          {
               Encryption encryption = new Encryption();
               if (UserInBlackList())
                    throw new CoreException(Errors.E00000001);
               switch ((UserStatusType)User.Status)
               {
                    case UserStatusType.ACTIVE:
                    case UserStatusType.DELETEPENDING:
                    case UserStatusType.TMPPASSWORD:
                         break;
                    default:
                         throw new CoreException(Errors.E00000002);
               }

               bool isUserValid = encryption.BCryptVerify(password, User.Password);
               if (!isUserValid)
               {
                    InsertLogDataLogin(false);
                    throw new CoreException(Errors.E00000004);
               }

          }
          protected virtual void LoadUser(long user)
          {
               User.Load(user);
               if (User.EOF)
                    throw new CoreException(Errors.E00000005);
          }
          protected virtual void LoadUser(string user)
          {
               User.Load(x => x.UserName == user || x.Email == user);
               if (User.EOF)
                    throw new CoreException(Errors.E00000005);
          }
          private bool UserInBlackList()
          {
               StringBuilder query = new StringBuilder();
               query.AppendFormat("SELECT count(UserNumber) FROM [Users].[BlackList] where UserNumber = {0}", User.Id);
               return Connection.ExecuteScalar<int>(query) > 0;
          }
          private void InsertLogDataLogin(bool status)
          {
               StringBuilder query = new StringBuilder();
               query.AppendFormat(" INSERT INTO  [Users].[Access](UserNumber,Product,Status)", this.Connection.TableName("UsersAccess"));
               query.AppendFormat(" VALUES (@UserNumber ,@Product,@Status)");
               this.Connection.ExecuteCommand(query,
               [
                    new ParameterSql("@UserNumber", User.Id),
                    new ParameterSql("@Product", (int)0),
                    new ParameterSql("@Status", status ? 0 : 1)
               ]);
          }
          private void LoadInfoUserSession()
          {
               Session.User.Number = User.Id;
               Session.User.Uuid = User.Uuid;
               Session.User.Email = User.Email;
               Session.User.PhoneCode = User.PhoneCode;
               Session.User.PhoneNumber = User.PhoneNumber;               
               Session.User.UserName = User.UserName;
               Session.User.Status = User.Status;
               Accounts.Load(User.Id);
               Session.User.FirstName = Accounts.FirstName;
               Session.User.LastName = Accounts.LastName;
          }
          private void LoadTermsAndCoditions()
          {
               spGetUsersTermsAndConditions spGetUsersTermsAndConditions = new spGetUsersTermsAndConditions(Connection)
               {
                    Company = Session.Company.Number,
                    UserNumber = Session.User.Number,
               };
               List<TermAndConditionDocument>? documents = spGetUsersTermsAndConditions.GetList<TermAndConditionDocument>();
               if(documents == null || documents.Count == 0)
               {
                    HasTermsStatus = false;
                    return;
               }
               TermsServices = documents;
               HasTermsStatus = true;               
               foreach (var document in TermsServices)
               {
                    if (document.Status == 0 || document.Status == 1)
                    {
                         HasTermsStatus = false;
                         return;
                    }
               }               
          }
          private void LoadCompanyInfo(long companyNumber)
          {
               Session.Company.Number = companyNumber;
               Companies company = new Companies(this);
               company.Load(Session.Company.Number);
               if (company.EOF)
                    throw new CoreException(Errors.E00000015);
               if (company.Status == 0)
                    throw new CoreException(Errors.E00000016);
               Session.Company.BusinessName = company.DisplayName;
               Session.Company.Email = company.Email;
               Session.Company.Country = (CountryType)company.CountryCode;

               //CompaniesUsers companyUser = new CompaniesUsers(this);
               //companyUser.Load(x => x.UserNumber == 0 && x.Company == companyNumber);
               //if (companyUser.EOF)
               //     throw new CoreException(Errors.E00000009);
               //Session.Company.WalletId = companyUser.Id;
          }
          private void LoadUserWalletInfo(long companyNumber)
          {
               CompaniesUsers companyUser = new CompaniesUsers(this);
               companyUser.Load(x => x.UserNumber == User.Id && x.Company == companyNumber);
               if (companyUser.EOF)
                    throw new CoreException(Errors.E00000009);
               Session.User.WalletId = companyUser.Id;
          }

     }
}
