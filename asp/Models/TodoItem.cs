using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models;

[Table("TodoList")]
public class TodoItem
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public bool IsComplete { get; set; }
}