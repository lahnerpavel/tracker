using AutoMapper;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
using Tracker.Data.Interfaces;
using Tracker.Data.Models;

namespace Tracker.Api.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieRepository movieRepository;
        private readonly IPersonRepository personRepository;
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;


        public MovieManager(
            IMovieRepository movieRepository,
            IPersonRepository personRepository,
            IGenreRepository genreRepository,
            IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.personRepository = personRepository;
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }


        public MovieDto AddMovie(MovieDto movieDto)
        {
            Movie movie = mapper.Map<Movie>(movieDto);

            movie.Actors.AddRange(personRepository.FindAllByIds(movieDto.ActorIds));
            movie.Genres.AddRange(genreRepository.FindAllByNames(movieDto.Genres));
            movie.DateAdded = DateTime.UtcNow;

            Movie addedMovie = movieRepository.Insert(movie);
            return mapper.Map<MovieDto>(addedMovie);
        }

        public IList<MovieDto> GetAllMovies(MovieFilterDto? movieFilterDto = null)
        {
            IList<Movie> movies = movieFilterDto is null ?
                movieRepository.GetAll() :
                movieRepository.GetAll(
                    movieFilterDto.DirectorId,
                    movieFilterDto.ActorId,
                    movieFilterDto.Genre,
                    movieFilterDto.FromYear ?? int.MinValue,
                    movieFilterDto.ToYear ?? int.MaxValue,
                    movieFilterDto.Limit ?? int.MaxValue);

            return mapper.Map<IList<MovieDto>>(movies);
        }

        public ExtendedMovieDto? GetMovie(uint movieId)
        {
            Movie? movie = movieRepository.FindById(movieId);

            if (movie is null)
                return null;

            return mapper.Map<ExtendedMovieDto>(movie);
        }

        public MovieDto? UpdateMovie(uint movieId, MovieDto movieDto)
        {
            Movie? dbMovie = movieRepository.FindById(movieId);

            if (dbMovie is null)
                return null;

            DateTime dateAdded = dbMovie.DateAdded;

            mapper.Map<MovieDto, Movie>(movieDto, dbMovie);

            // V DTO mohla být nesprávná hodnota ID, je třeba ji nastavit zpět na správnou
            dbMovie.MovieId = movieId;
            // Datum bylo při mapování přepsáno nesprávnou hodnotou, musíme jej nastavit zpět na správnou
            dbMovie.DateAdded = dateAdded;

            IList<Person> actors = personRepository.FindAllByIds(movieDto.ActorIds);
            IList<Genre> genres = genreRepository.FindAllByNames(movieDto.Genres);

            foreach (Person actor in dbMovie.Actors.Except(actors).ToList())
                dbMovie.Actors.Remove(actor);
            foreach (Genre genre in dbMovie.Genres.Except(genres).ToList())
                dbMovie.Genres.Remove(genre);

            dbMovie.Actors.AddRange(actors.Except(dbMovie.Actors));
            dbMovie.Genres.AddRange(genres.Except(dbMovie.Genres));

            Movie updatedMovie = movieRepository.Update(dbMovie);
            return mapper.Map<MovieDto>(updatedMovie);
        }

        public MovieDto? DeleteMovie(uint movieId)
        {
            if (!movieRepository.ExistsWithId(movieId))
                return null;

            Movie dbMovie = movieRepository.FindById(movieId)!;
            MovieDto movieDto = mapper.Map<MovieDto>(dbMovie);

            dbMovie.Actors.Clear();
            dbMovie.Genres.Clear();
            movieRepository.Update(dbMovie);

            movieRepository.Delete(movieId);

            return movieDto;
        }
    }
}