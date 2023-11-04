using Tracker.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Repositories
{
    public class VehicleLocationRepository : BaseRepository<VehicleLocation>, IVehicleLocationRepository
    {
        public VehicleLocationRepository(TrackerDbContext trackerDbContext) : base(trackerDbContext)
        {
        }


        public IList<VehicleLocation> GetAll(int page, int pageSize)
        {
            return dbSet
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IList<VehicleLocation> FindAllByIds(IEnumerable<uint> ids)
        {
            return dbSet.Where(l => ids.Contains(l.LocationId)).ToList();
        }
    }
}