namespace Shelly.GraphQLCore.GraphQL.Query.Dashboard
{
     internal partial class Queries
     {
          public void FieldsAuthentication()
          {
               Field<String>("getTwoFactorInformation")
                    .Resolve(GetTwoFactorInformation);
               Field<LoginType>("getLogin2fa")
                    .Argument<string>("code")
                    .Resolve(GetLogin2fa);
               Field<Boolean>("getLogout")
                    .Resolve(GetLogout);
               Field<Boolean>("getRefreshToken")
                   .Resolve(GetRefreshToken);
               Field<string>("getSecurityCode")
                  .Argument<string>("code")
                  .Resolve(GetSecurityCode);
          }
          private string? GetTwoFactorInformation(IResolveFieldContext context) => context.TryTwoFactor(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               TwoFactorAuth tfa = new TwoFactorAuth("AppAccounts", qrcodeprovider: new QRCoderQRCodeProvider());
               UsersSecurity user = new UsersSecurity(_System);
               user.Load(_System.Session.User.Number, (int)UserSecurityType.ThirtPary);
               if (user.EOF)
               {
                    user.New();
                    user.UserNumber = _System.Session.User.Number;
                    user.Id = (int)UserSecurityType.ThirtPary;
                    user.CreatedAt = DateTime.Now;
               }
               if (string.IsNullOrEmpty(user.KeyValue))
                    user.KeyValue = tfa.CreateSecret(160);
               if (user.Status != (int)UserStatusSecurityType.PRIMARY)
                    user.Status = (int)UserStatusSecurityType.PENDING;
               user.Save();
               return user.KeyValue;
          });
          private LoginInfo? GetLogin2fa(IResolveFieldContext context) => context.TryTwoFactor(() =>
          {
               using ConnectionHandler manager = new ConnectionHandler(_System.Connection);
               _System.Session.User.Number = _System.InfoSessionToken.UserNumber;
               _System.Session.User.Uuid = _System.InfoSessionToken.Uuid;
               TwoFactorAuth tfa = new TwoFactorAuth("AppAccounts", qrcodeprovider: new QRCoderQRCodeProvider());
               UsersSecurity user = new UsersSecurity(_System);
               user.Load(_System.Session.User.Number, (int)UserSecurityType.ThirtPary);
               if (user.EOF)
               {
                    user.New();
                    user.UserNumber = _System.Session.User.Number;
                    user.Id = (int)UserSecurityType.ThirtPary;
                    user.CreatedAt = DateTime.Now;
                    user.KeyValue = tfa.CreateSecret(160);
                    user.Status = (int)UserStatusSecurityType.PENDING;
                    user.Save();
                    context.Errors.Add(new ShellyExecutionError("E00000018"));
                    return null;
               }
               if (!tfa.VerifyCode(user.KeyValue, context.GetArgument<string>("code")) && user.Code != context.GetArgument<string>("code"))
                    throw new CoreException(Errors.E00000021);
               _System.Cache.TwoFactorsRemoveKey(_System.InfoSessionToken.Token);
               user.Load(_System.Session.User.Number, (int)UserSecurityType.ThirtPary);
               user.Status = (int)UserStatusSecurityType.PRIMARY;
               user.Save();
               string token = TokenGenerator.GenerateTokenJwt(_System.Session.User.Email, _System.Session.User.Uuid);
               _System.InfoSessionToken.Token = token;
               _System.InfoSessionToken.HasTwoFactor = true;
               _System.InfoSessionToken.SecreteCode = "";
               _System.Cache.AuthStoreData(token, _System.InfoSessionToken);
               return _System.InfoSessionToken;
          });

          private bool GetLogout(IResolveFieldContext context) => context.Try(() =>
          {
               if (_System.InfoSessionToken.AuthConstant == Authentication.LOGGED)
                    _System.Cache.AuthRemoveKey(_System.InfoSessionToken.Token);
               if (_System.InfoSessionToken.AuthConstant == Authentication.LOGGETWOFACTOR)
                    _System.Cache.TwoFactorsRemoveKey(_System.InfoSessionToken.Token);
               return true;
          });

          private bool GetRefreshToken(IResolveFieldContext context) => context.Try(() =>
          {
               if (_System.InfoSessionToken.AuthConstant == Authentication.LOGGED)
                    _System.Cache.AuthStoreData(_System.InfoSessionToken.Token, _System.InfoSessionToken);
               if (_System.InfoSessionToken.AuthConstant == Authentication.LOGGETWOFACTOR)
                    _System.Cache.TwoFactorsStoreData(_System.InfoSessionToken.Token, _System.InfoSessionToken);
               return true;
          });

          private string? GetSecurityCode(IResolveFieldContext context) => context.TryLogged(() =>
          {
               TwoFactorAuth tfa = new TwoFactorAuth("AppAccounts", qrcodeprovider: new QRCoderQRCodeProvider());
               UsersSecurity user = new UsersSecurity(_System);
               user.Load(_System.Session.User.Number, (int)UserSecurityType.ThirtPary);
               string code = context.GetArgument<string>("code");
               if (!tfa.VerifyCode(user.KeyValue, context.GetArgument<string>("code")) && user.Code != context.GetArgument<string>("code"))
                    throw new CoreException(Errors.E00000021);

               SecurityCodeTransactions securityCode = new SecurityCodeTransactions(_System);
               securityCode.New();
               securityCode.Uuid = Guid.NewGuid().ToString().ToUpper();
               securityCode.UserNumber = _System.Session.User.Number;
               securityCode.Code = code;
               securityCode.Timeout = 5;
               securityCode.Processed = false;
               securityCode.CreateAt = DateTime.Now;
               securityCode.Save();
               return securityCode.Uuid;
          });
     }
}
