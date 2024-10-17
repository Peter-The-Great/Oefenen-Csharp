using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace movies.Models;

public class Review
{
    public int Id { get; set; }

    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
    public int Rating { get; set; }

    [MaxLength(50, ErrorMessage = "Username can be at most 50 characters long.")]
    public string UserName { get; set; }

    [MaxLength(1000, ErrorMessage = "Description can be at most 1000 characters long.")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}