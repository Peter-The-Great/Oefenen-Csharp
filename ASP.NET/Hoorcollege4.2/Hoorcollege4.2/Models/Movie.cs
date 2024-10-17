using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoorcollege4._2.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }
        [Range(1000, 9999)]
        public int Year { get; set; }

        public List<Review> Reviews { get; set; } = [];

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        private Movie() { }

        public Movie(string title, int year, int directorId)
        {
            Title = title;
            Year = year;
            DirectorId = directorId;
        }
    }
}
