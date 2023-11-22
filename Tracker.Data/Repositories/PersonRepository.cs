using Tracker.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(TrackerDbContext trackerDbContext) : base(trackerDbContext)
        {
        }


        public IList<Person> GetAll(PersonRole personRole, int page, int pageSize)
        {
            return dbSet
                .Where(p => p.Role == personRole)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IList<Person> FindAllByIds(IEnumerable<uint> ids)
        {
            return dbSet.Where(p => ids.Contains(p.PersonId)).ToList();
        }
    }
}