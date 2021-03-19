using System;
using System.Threading.Tasks;

namespace BackgroundScrutor
{
    public interface ICacheService
    {
        Task<string> GetCachedValueAsync(string key);
        Task SetCachedValueAsync(string key, string value);
        Task SetCachedValueAsync(string key, string value, TimeSpan expirationTime);
    }
}
