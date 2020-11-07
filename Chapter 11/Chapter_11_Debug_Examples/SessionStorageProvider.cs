using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Chapter11
{
    public class SessionStorageProvider : IStorageProvider
    {
        private readonly IJSRuntime jSRuntime;

        public SessionStorageProvider(IJSRuntime jsRuntime)
        {
            jSRuntime = jsRuntime;
        }

        public async Task<string> Get(string key)
        {
            return await jSRuntime.InvokeAsync<string>("GetSessionStorage", key);
        }

        async Task IStorageProvider.Set(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("SetSessionStorage", key, value);
        }
    }
}
