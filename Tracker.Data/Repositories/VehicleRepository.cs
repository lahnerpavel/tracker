using Tracker.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(TrackerDbContext trackerDbContext) : base(trackerDbContext)
        {
        }


        /*public IList<Vehicle> GetAll(int page, int pageSize)
        {
            return dbSet
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }*/

        /*public IList<Vehicle> GetAll()
        {
            return dbSet.ToList();
        }*/

        public IList<Vehicle> FindAllByIds(IEnumerable<uint> ids)
        {
            return dbSet.Where(v => ids.Contains(v.VehicleId)).ToList();
        }
    }
}