using Shelly.Abstractions.Settings;

namespace Shelly.GraphQLCore.GraphQL.Helper
{
     public static class GraphQLHelper
     {
          public static T? TryLogged<T>(this IResolveFieldContext context,Func<T> function)
          {
               try
               {
                    if (context.GetInputExtension<string>("AuthConstant") != Authentication.LOGGED)
                    {
                         context.Errors.Add(new ShellyExecutionError(Errors.E00000019, "LOGGED"));
                         return default;
                    }
                    return function();
               }                
               catch (CoreException ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.ErrorId, ex.AdditionalMessage));
                    
               }
               catch (Exception ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.Message, ex));
                    
               }
               return default;
          }
          public static T? TryLogged2fa<T>(this IResolveFieldContext context, BaseSystem system, Func<T> function)
          {
               try
               {
                    if (context.GetInputExtension<string>("AuthConstant") != Authentication.LOGGED)
                    {
                         context.Errors.Add(new ShellyExecutionError(Errors.E00000019, "LOGGED"));
                         return default;
                    }
                    if (!ValidateSecurityCode(context, system))
                         return default;
                    return function();
               }
               catch (CoreException ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.ErrorId, ex.AdditionalMessage));

               }
               catch (Exception ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.Message, ex));

               }
               return default;
          }
          public static T? TryTwoFactor<T>(this IResolveFieldContext context, Func<T> function)
          {
               try
               {
                    if (context.GetInputExtension<string>("AuthConstant") != Authentication.LOGGETWOFACTOR)
                    {
                         context.Errors.Add(new ShellyExecutionError(Errors.E00000019, "TWOFACTOR"));
                         return default;
                    }
                    return function();
               }
               catch (CoreException ex)
               {
                    context.Errors.Add(new ShellyExecutionError(ex.ErrorId, ex.AdditionalMessage));

               }
               catch (Exception ex)
               {
                    context.Errors.Add(new ShellyExecutionError(ex.Message, ex));

               }
               return default;
          }
          public static T? Try<T>(this IResolveFieldContext context, Func<T> function)
          {
               try
               {
                    return function();
               }
               catch (CoreException ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.ErrorId, ex.AdditionalMessage));

               }
               catch (Exception ex)
               {
                    ConnectionHandler.RollbackTransaction();
                    context.Errors.Add(new ShellyExecutionError(ex.Message, ex));

               }
               return default;
          }
          public static T? GetInputExtension<T>(this IResolveFieldContext context, string path)
          {               
               var value = context.GetInputExtension(path);
               if (Convert.IsDBNull(value) || String.IsNullOrEmpty(Convert.ToString(value)))
                    return ExtensionStrings.GetDefaultValue<T>();
               return (T?)Convert.ChangeType(value, typeof(T));
          }
          private static bool ValidateSecurityCode(IResolveFieldContext context, BaseSystem system)
          {
               string code = context.GetArgument<string>("code");
               if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(code.Trim()) || !Guid.TryParse(code, out Guid guidOutput))
               {
                    context.Errors.Add(new ShellyExecutionError(Errors.E00000021));
                    return false;
               }
               SecurityCodeTransactions securityCode = new SecurityCodeTransactions(system);
               securityCode.Load(x => x.Uuid == code && x.UserNumber == system.Session.User.Number);
               if (securityCode.EOF)
               {
                    context.Errors.Add(new ShellyExecutionError(Errors.E00000021));
                    return false;
               }
               if (securityCode.Processed)
               {
                    context.Errors.Add(new ShellyExecutionError(Errors.E00000021));
                    return false;
               }
               TimeSpan diff = DateTime.Now.ToUniversalTime().Subtract(securityCode.CreateAt);
               securityCode.Processed = true;
               securityCode.Save();
               if (diff.TotalMinutes >= securityCode.Timeout)
               {

                    context.Errors.Add(new ShellyExecutionError(Errors.E00000021));
                    return false;
               }
               return true;
          }
        
     }
}
