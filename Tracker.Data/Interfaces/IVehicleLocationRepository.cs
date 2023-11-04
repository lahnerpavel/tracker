using Eshop.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Interfaces
{
    public interface IVehicleLocationRepository : IBaseRepository<VehicleLocation>
    {
        IList<VehicleLocation> GetAll(int page, int pageSize);
        IList<VehicleLocation> FindAllByIds(IEnumerable<uint> ids);
    }
}