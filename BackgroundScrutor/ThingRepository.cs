using System.Threading.Tasks;

namespace BackgroundScrutor
{
    public class ThingRepository : IThingRepository
    {
        public Task<string> Get(string id)
        {
            return Task.FromResult("aaaaaaa1");
        }
    }
}
