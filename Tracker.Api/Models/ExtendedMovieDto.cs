using System.Text.Json.Serialization;

namespace Tracker.Api.Models
{
    public class ExtendedMovieDto : MovieDto
    {
        [JsonPropertyName("director")]
        public PersonDto Director { get; set; } = new PersonDto();
        [JsonPropertyName("actors")]
        public List<PersonDto> Actors { get; set; } = new List<PersonDto>();
    }
}
