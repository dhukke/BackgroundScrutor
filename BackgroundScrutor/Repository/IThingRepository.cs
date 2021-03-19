using System.Threading.Tasks;

namespace BackgroundScrutor.Repository
{
    public interface IThingRepository
    {
        Task<string> Get(string id);
    }
}
