using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackgroundScrutor
{
    public interface IThingRepository
    {
        Task<string> Get(string id);
    }
}
