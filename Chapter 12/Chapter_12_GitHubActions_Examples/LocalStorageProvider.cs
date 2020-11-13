using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Chapter12
{
    public class LocalStorageProvider : IStorageProvider
    {
        private readonly IJSRuntime jSRuntime;

        public LocalStorageProvider(IJSRuntime jsRuntime)
        {
            jSRuntime = jsRuntime;
        }

        public async Task<string> Get(string key)
        {
            return await jSRuntime.InvokeAsync<string>("GetLocalStorage", key);
        }

        async Task IStorageProvider.Set(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("SetLocalStorage", key, value);
        }
    }    
}
