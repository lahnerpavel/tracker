using Eshop.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Data.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        IList<Movie> GetAll(
            uint? directorId = null,
            uint? actorId = null,
            string? genre = null,
            int? fromYear = null,
            int? toYear = null,
            int? limit = null);
    }
}