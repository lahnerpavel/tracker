using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Data.Models
{
    public enum PersonRole
    {
        Actor, Director
    }

    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public uint PersonId { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; } = "";
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Country { get; set; } = "";
        [Required]
        public string Biography { get; set; } = "";
        [Required]
        public PersonRole Role { get; set; }

        public virtual List<Movie> MoviesAsActor { get; set; } = new List<Movie>();

        public virtual List<Movie> MoviesAsDirector { get; set; } = new List<Movie>();
    }
}