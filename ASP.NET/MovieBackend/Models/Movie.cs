using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace movies.Models;

public class Movie
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "Title can be at most 100 characters long.")]
    public string Title { get; set; }

    [Range(1000, 9999, ErrorMessage = "Year must be a 4-digit number.")]
    public int Year { get; set; }

    [ForeignKey("Director")]
    public int DirectorId { get; set; }
    public Director Director { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}