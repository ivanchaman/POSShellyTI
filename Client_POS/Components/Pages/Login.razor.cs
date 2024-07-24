namespace ShellyPOS.Components.Pages
{
    public partial class Login
    {
        public LoginModel loginModel = new LoginModel();
        private async Task HandleLogin()
        {
            var response = await HttpService.Get<LoginInfoResponse, LoginModel>(new LoginRequest<LoginModel>()
            {                
                Variables = new LoginModel()
                {
                    User = loginModel.User,
                    Password = loginModel.Password,
                    Company = 1
                }
            });
            // Dummy login logic
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