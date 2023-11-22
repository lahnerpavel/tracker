using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Interfaces;

namespace Tracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreManager genreManager;


        public GenresController(IGenreManager genreManager)
        {
            this.genreManager = genreManager;
        }


        [HttpGet]
        public IEnumerable<string> GetGenres()
        {
            return genreManager.GetAllGenres();
        }
    }
}