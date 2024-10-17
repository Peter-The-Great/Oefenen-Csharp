using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace movies.Models;

public class Director
{
    public int Id { get; set; }
    
    [MaxLength(50, ErrorMessage = "Name can be at most 50 characters long.")]
    public string Name { get; set; }

    public ICollection<Movie> Movies { get; set;} = new List<Movie>();
}