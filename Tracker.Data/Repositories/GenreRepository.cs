using Tracker.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(TrackerDbContext trackerDbContext) : base(trackerDbContext)
        {
        }


        public IList<Genre> FindAllByNames(IEnumerable<string> names)
        {
            return dbSet.Where(g => names.Contains(g.Name)).ToList();
        }
    }
}
