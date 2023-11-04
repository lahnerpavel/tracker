using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Data.Models
{
    public class VehicleLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public uint LocationId { get; set; }

        [Required]
        public uint VehicleId { get; set; } // Identifikátor vozidla, ke kterému patří tato poloha

        public virtual Vehicle? Vehicle { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } // Časová značka polohy

        [Required]
        public double Latitude { get; set; } // Zeměpisná šířka

        [Required]
        public double Longitude { get; set; } // Zeměpisná délka

        // Další vlastnosti polohy, například rychlost, směr, atd.

    }
}