using Hoorcollege4._2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hoorcollege4._2
{
    public class MyContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=bioscoop.db");
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
