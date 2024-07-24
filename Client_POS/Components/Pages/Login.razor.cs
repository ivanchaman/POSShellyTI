using Shelly.GraphQLCoreClient.Model;

namespace ShellyPOS.Components.Pages
{
    public partial class Login
    {
        public LoginData loginModel = new LoginData();
        private async Task HandleLogin()
        {
            var response = await LoginServices.Login(loginModel);            
            if (response.Result)
            {
                var authStateProvider = (CustomAuthStateProvider)AuthenticationStateProvider;
                await authStateProvider.MarkUserAsAuthenticated(loginModel.User);
                Navigation.NavigateTo("/");
            }
            else
            {                
                NotificationService.Notify(NotificationSeverity.Error, response.Errors[0].HeaderDefinition, response.Errors[0].DefaultMessage);
            }
        }
    }
}