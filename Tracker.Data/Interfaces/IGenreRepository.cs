using Eshop.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        IList<Genre> FindAllByNames(IEnumerable<string> names);
    }
}