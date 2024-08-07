using Microsoft.JSInterop;

namespace ShellyPOS.Helpers
{
    public static class IJSRuntimersExtensionMethods
    {
        public static async ValueTask InicializarTimerInactivo<T>(this IJSRuntime js, DotNetObjectReference <T> dotNetObjectReference) where T: class
        {
            await js.InvokeVoidAsync("timerInactivo", dotNetObjectReference);
        }
    }
}
