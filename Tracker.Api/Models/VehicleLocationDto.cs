using Tracker.Data.Models;
using System.Text.Json.Serialization;

namespace Tracker.Api.Models
{
    public class VehicleLocationDto
    {
        [JsonPropertyName("_id")]
        public uint LocationId { get; set; }

        [JsonPropertyName("vehicleID")]
        public uint VehicleId { get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        // Další vlastnosti polohy, například rychlost, směr, atd.

    }
}