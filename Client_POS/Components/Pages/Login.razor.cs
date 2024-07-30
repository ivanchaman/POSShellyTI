namespace ShellyPOS.Components.Pages
{
     public partial class Login
     {
          protected override async Task OnInitializedAsync()
          {
               //string userName = await LocalStorageService.GetItem<string>("UserName");               
               await base.OnInitializedAsync();
          }

          private async Task OnLogin(LoginArgs args)
          {
               var response = await LoginServices.Login(new LoginData() { User = args.Username, Password = args.Password });
               if (response.Result)
               {
                    if (args.RememberMe == true)
                    {
                        await LocalStorageService.SetItemAsync("UserName", args.Username);
                    }
                    await LocalStorageService.SetItemAsync("Token", response.Response);
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