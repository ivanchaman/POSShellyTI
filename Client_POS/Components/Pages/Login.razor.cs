using Shelly.GraphQLCoreClient.Model;

namespace ShellyPOS.Components.Pages
{
    public partial class Login
    {          
        private async Task OnLogin(LoginArgs args)
        {
            var response = await LoginServices.Login(new LoginData() { User = args.Username, Password = args.Password });
            if (response.Result)
            {
                Navigation.NavigateTo("/");
            }
            else
            {
                NotificationService.Notify(NotificationSeverity.Error, response.Errors[0].HeaderDefinition, response.Errors[0].DefaultMessage);
            }
        }

        private async Task OnRegister()
        {

        }

        private async Task OnResetPassword(string args)
        {

        }
    }
}