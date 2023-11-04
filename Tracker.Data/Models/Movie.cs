using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Data.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public uint MovieId { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; } = "";
        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

        // Když smažu režiséra, nechci smazat jeho filmy
        [ForeignKey(nameof(Director))]
        public uint? DirectorId { get; set; }
        public virtual Person? Director { get; set; }

        public virtual List<Person> Actors { get; set; } = new List<Person>();

        public virtual List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
