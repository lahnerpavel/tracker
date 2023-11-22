using Tracker.Api.Models;

namespace Tracker.Api.Interfaces
{
    public interface IMovieManager
    {
        MovieDto AddMovie(MovieDto movieDto);
        IList<MovieDto> GetAllMovies(MovieFilterDto? movieFilterDto = null);
        ExtendedMovieDto? GetMovie(uint movieId);
        MovieDto? UpdateMovie(uint movieId, MovieDto movieDto);
        MovieDto? DeleteMovie(uint movieId);
    }
}