using CoOp19.Lib.Models;
using System.Threading.Tasks;

namespace CoOp19.Lib
{
    public interface IPost
    {
        Task AddConsumable(ConsumableViewResource item);
        Task AddGeneric(GenericViewResource item);
        Task AddHealthResource(HealthViewResource item);
        Task AddHealthResourceService(HealthViewResourceService item);
        Task AddMapData(ViewMapData item);
        Task AddShelterResource(ShelterViewResource item);
        Task AddUser(UsersView item);
    }
}