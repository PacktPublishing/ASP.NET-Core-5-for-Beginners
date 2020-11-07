using System.Threading.Tasks;

namespace Chapter11
{
    public interface IStorageProvider
    {
        Task Set(string key, string value);
        Task<string> Get(string key);
    }
}
