using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=blogging.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
        .HasMany(b => b.Posts)
        .WithOne(p => p.Blog)
        .OnDelete(DeleteBehavior.Cascade);
    }
}

public class Blog
{
    [Key]
    public int BlogId { get; set; }
    [MaxLength(500)]
    public string? Url { get; set; }
    public List<Post> Posts { get; } = new();
}

public class Post
{
    [Key]
    public int PostId { get; set; }
    [MaxLength(500)]
    public string? Title { get; set; }
    public string? Content { get; set; }

    public int? BlogId { get; set; }
    public Blog? Blog { get; set; }
}