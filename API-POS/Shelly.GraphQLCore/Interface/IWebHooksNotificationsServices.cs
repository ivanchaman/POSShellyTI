namespace Shelly.GraphQLCore.Interface
{
     internal interface IWebHooksNotificationsServices
     {
          public Task NMIPaymentGatewayNotitications(object jobject);
          public Task FireblocksNotitications(object jobject);
          public Task FinicityNotitications(object jobject);
     }
}
