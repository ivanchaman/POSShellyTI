using Blazored.LocalStorage;
using Microsoft.JSInterop;
using Shelly.GraphQLCoreClient.Services;
using ShellyPOS.Helpers;

namespace ShellyPOS.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        private bool sidebarExpanded = true;

        void SidebarToggleClick()
        {
            sidebarExpanded = !sidebarExpanded;
        }

        protected override async void OnInitialized()
        {
            await js.InicializarTimerInactivo(DotNetObjectReference.Create(this));
            base.OnInitialized();
        }
        [JSInvokable]
        public async Task RefresToken()
        {
            LoginResponse token = await LocalStorageService.GetItemAsync<LoginResponse>(ItemsStorages.Token);
            if (token == null || string.IsNullOrEmpty (token.Token))
            {
                Navigation.NavigateTo("/logout");
                return;
            }            
            var response = await AuthenticationServices.RefreshToken(token.Token);
            if(response.Data == null || !response.Result || !response.Response)
            {
                Navigation.NavigateTo("/logout");
                return;
            }
            await LocalStorageService.SetItemAsync(ItemsStorages.Token, token);            
        }
    }
}
