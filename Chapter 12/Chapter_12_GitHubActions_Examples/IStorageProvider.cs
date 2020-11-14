using System.Threading.Tasks;

namespace Chapter12
{
    public interface IStorageProvider
    {
        Task Set(string key, string value);
        Task<string> Get(string key);
    }
}
