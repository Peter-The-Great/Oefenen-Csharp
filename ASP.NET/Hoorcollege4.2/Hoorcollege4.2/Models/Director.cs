using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hoorcollege4._2.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = [];

        private Director() { }

        public Director(string name)
        {
            Name = name;
        }
    }
}
