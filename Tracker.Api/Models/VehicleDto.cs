using Tracker.Data.Models;
using System.Text.Json.Serialization;

namespace Tracker.Api.Models
{
    public class VehicleDto
    {
        [JsonPropertyName("_id")]
        public uint VehicleId { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("registrationNumber")]
        public string? RegistrationNumber { get; set; }

        //[JsonPropertyName("locations")]
        //public object? Locations { get; internal set; }

        // Další vlastnosti vozidla, například rok výroby, barvu, atd.

        [JsonPropertyName("locationIDs")]
        public virtual List<uint> LocationIds { get; set; } = new List<uint>();
    }
}