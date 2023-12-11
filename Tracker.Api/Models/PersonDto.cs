using Tracker.Data.Models;
using System.Text.Json.Serialization;

namespace Tracker.Api.Models
{
    public class PersonDto
    {
        [JsonPropertyName("_id")]
        public uint PersonId { get; set; }
        public string Name { get; set; } = "";
        public DateTimeOffset BirthDate { get; set; }
        public string Country { get; set; } = "";
        public string Biography { get; set; } = "";
        public PersonRole Role { get; set; }
    }
}