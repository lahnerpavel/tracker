using Eshop.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IList<Person> GetAll(PersonRole personRole, int page, int pageSize);
        IList<Person> FindAllByIds(IEnumerable<uint> ids);
    }
}