using Hoorcollege4._2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hoorcollege4._2.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }
        [Range(1000, 9999)]
        public int Year { get; set; }

        public int DirectorId { get; set; }

        public MovieDto(int id, string title, int year, int directorId)
        {
            Id = id;
            Title = title;
            Year = year;
            DirectorId = directorId;

        }
    }
}
