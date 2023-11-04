using Eshop.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        /*IList<Vehicle> GetAll();*/
        IList<Vehicle> FindAllByIds(IEnumerable<uint> ids);
    }
}

//IList<Vehicle> GetAll(int page, int pageSize);