using System.Threading.Tasks;

namespace BackgroundScrutor.Repository
{
    public class ThingRepository : IThingRepository
    {
        public Task<string> Get(string id)
        {
            return Task.FromResult("aaaaaaa1");
        }
    }
}
