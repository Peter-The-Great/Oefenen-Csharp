using Microsoft.EntityFrameworkCore;
namespace movies.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, Name = "Steven Spielberg" },
            new Director { Id = 2, Name = "Christopher Nolan" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Jurassic Park", Year = 1993, DirectorId = 1 },
            new Movie { Id = 2, Title = "Inception", Year = 2010, DirectorId = 2 }
        );

        modelBuilder.Entity<Review>().HasData(
            new Review { Id = 1, Rating = 5, Description = "Amazing!", UserName = "JohnDoe", CreatedAt = DateTime.Now, MovieId = 1 },
            new Review { Id = 2, Rating = 4, Description = "Great movie!", UserName = "JaneDoe", CreatedAt = DateTime.Now, MovieId = 2 }
        );
    }
}