namespace Shelly.GraphQLCore.GraphQL.Mutation.Accounts
{
     public partial class Mutations
     {
          public void FieldsUsers()
          {
               Field<Boolean>("setInformation")
                    .Argument<UsersAccountsInputType>("data")
                    .Resolve(SetAccountInformation);
               Field<Boolean>("setAvatarImage")
                    .Argument<long>("data")
                    .Resolve(SetAvatarImage);
               Field<Boolean>("setUseBillingToShipping")
                   .Argument<bool>("data")
                   .Resolve(SetUseBillingToShipping);
               Field<Boolean>("setSSN")
                   .Argument<string>("data")
                   .Resolve(SetSSN);               
               Field<Boolean>("setAddresses")
                    .Argument<ListGraphType<UsersAddressInputType>>("data")
                    .Resolve(SetAddresses);
               Field<Boolean>("setUpdatePassword")
                    .Argument<string>("code")
                    .Argument<string>("data")
                    .Resolve(SetUpdatePassword);
               Field<Boolean>("setDeleteAccount")
                    .Argument<string>("code")
                    .Resolve(SetDeleteAccount);
          }
          #region Users



          private bool SetAccountInformation(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               UsersAccounts user = new UsersAccounts(_System);
               UsersAccounts data = context.GetArgument<UsersAccounts>("data");
               user.Load(_System.Session.User.Number);
               user.FirstName = data.FirstName;
               user.MiddleName = data.MiddleName;
               user.LastName = data.LastName;
               user.AvatarImageId = data.AvatarImageId;
               user.SSNNationalId = data.SSNNationalId;
               user.Birthday = data.Birthday;
               user.Gender = data.Gender;
               user.PlaceOfBirth = data.PlaceOfBirth;
               user.Nationality = data.Nationality;
               user.IsComplete = data.IsComplete;
               user.Status = data.Status;
               user.UseBillingToShipping = data.UseBillingToShipping;
               user.Save();
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetAvatarImage(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               UsersAccounts user = new UsersAccounts(_System);
               user.Load(_System.Session.User.Number);
               user.AvatarImageId = context.GetArgument<long>("data");
               user.Save();
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetUseBillingToShipping(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               UsersAccounts user = new UsersAccounts(_System);
               user.Load(_System.Session.User.Number);
               user.UseBillingToShipping = context.GetArgument<bool>("data");
               user.Save();
               ConnectionHandler.CommitTransaction();
               return true;
          });
          private bool SetSSN(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               UsersAccounts user = new UsersAccounts(_System);
               user.Load(_System.Session.User.Number);
               user.SSNNationalId = context.GetArgument<string>("data");
               user.Save();
               ConnectionHandler.CommitTransaction();
               return true;
          });
      
          private bool SetAddresses(IResolveFieldContext context) => context.TryLogged(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               List<UsersAddress> data = context.GetArgument<List<UsersAddress>>("data");
               UsersAddress usersAddress = new UsersAddress(_System);
               data.ForEach(document =>
               {
                    usersAddress.Load(_System.Session.User.Number, document.Id);
                    if (usersAddress.EOF)
                    {
                         usersAddress.New();
                         usersAddress.UserNumber = _System.Session.User.Number;
                         usersAddress.Id = document.Id;
                    }
                    usersAddress.City = document.City;
                    usersAddress.Country = document.Country;
                    usersAddress.State = document.State;
                    usersAddress.Street = document.Street;
                    usersAddress.ZipCode = document.ZipCode;
                    usersAddress.IsComplete = document.IsComplete;
                    usersAddress.Save();
               });
               ConnectionHandler.CommitTransaction();
               return true;
          });

        
          private bool SetUpdatePassword(IResolveFieldContext context) => context.TryLogged2fa(_System, () =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               ConnectionHandler.BeginTransaction();
               Users user = new Users(_System);
               user.SetUpdatePassword(context.GetArgument<string>("data"));
               ConnectionHandler.CommitTransaction();
               return true;
          });

          private bool SetDeleteAccount(IResolveFieldContext context) => context.TryLogged2fa(_System,() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);               
               Users user = new Users(_System);
               user.SetDeleteAccount();
               //EmailServices sendEmail = new EmailServices(_System);
               //sendEmail.AddTo(_System.Session.User.Email);
               //sendEmail.AddData("days", $"{_System.GetParameter<int>("TotalDaysDeleteUsers")}");
               //sendEmail.AddData("userid", _System.Session.User.Uuid);
               //sendEmail.AddData("email", _System.Session.User.Email);
               //sendEmail.AddData("phone", $"{_System.Session.User.PhoneCode}-{_System.Session.User.PhoneNumber}");
               //sendEmail.Send("DeleteUserAccount");               
               return true;
          });
          #endregion



     }

}
