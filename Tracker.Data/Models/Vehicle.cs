using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Data.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public uint VehicleId { get; set; }

        [Required, MinLength(2)]
        public string? Brand { get; set; }

        [Required, MinLength(2)]
        public string? Model { get; set; }

        [Required]
        public string? RegistrationNumber { get; set; }

        // Další vlastnosti vozidla, například rok výroby, barvu, atd.

        public virtual List<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();  
    }
}