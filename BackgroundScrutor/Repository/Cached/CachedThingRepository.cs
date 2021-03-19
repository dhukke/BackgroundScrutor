using System;
using System.Threading.Tasks;
using BackgroundScrutor.Cache;

namespace BackgroundScrutor.Repository.Cached
{
    public class CachedThingRepository : IThingRepository
    {
        private readonly IThingRepository _thingRepository;
        private readonly ICacheService _cacheService;

        public CachedThingRepository(IThingRepository thingRepository, ICacheService cacheService)
        {
            _thingRepository = thingRepository;
            _cacheService = cacheService;
        }

        public async Task<string> Get(string id)
        {
            var value = await _cacheService.GetCachedValueAsync(id);

            if (!string.IsNullOrEmpty(value))
            {
                return $"cached value: {value}";
            }

            var valueFromDb = await  _thingRepository.Get(id);

            await _cacheService.SetCachedValueAsync(id, valueFromDb, TimeSpan.FromSeconds(10));

            return $"value from DB: {valueFromDb}";
        }
    }
}
