using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chapter12
{
    public class ApplicationStorage<TStorageProvider> where TStorageProvider : IStorageProvider
    {
        readonly IStorageProvider StorageProvider;
        readonly ILogger<ApplicationStorage<TStorageProvider>> Logger;

        public ApplicationStorage(TStorageProvider storageProvider, ILogger<ApplicationStorage<TStorageProvider>> logger)
        {
            StorageProvider = storageProvider;
            Logger = logger;
        }

        public async Task<UserState> GetUserState()
        {
            var value = await StorageProvider.Get("UserState");

            if (value == null)
            {
                Logger.LogDebug("UserState initialized.");
                return new UserState();
            }

            return JsonSerializer.Deserialize<UserState>(value);
        }

        public async Task SetUserState(UserState value)
        {
            await StorageProvider.Set("UserState", JsonSerializer.Serialize(value));
        }

    }
}
