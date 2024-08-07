using Radzen.Blazor;

namespace ShellyPOS.Components.Pages
{
     public partial class Login
     {
          string UserName { get; set; }
          protected override async Task OnInitializedAsync()
          {
                           
               await base.OnInitializedAsync();
          }
          protected override async Task OnAfterRenderAsync(bool firstRender)
          {
               if (firstRender)
               {
                    UserName = await LocalStorageService.GetItemAsStringAsync("UserName");                    
                    StateHasChanged();
               }
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