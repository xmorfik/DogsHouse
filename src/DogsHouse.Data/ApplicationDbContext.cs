using DogsHouse.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DogsHouse.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Dog> Dogs { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Dog>().HasData(
            new Dog
            {
                Id = 1,
                Name = "Neo",
                Colour = "red & amber",
                TailLength = 22,
                Weight = 32,
            },
            new Dog
            {
                Id = 2,
                Name = "Jessy",
                Colour = "black & white",
                TailLength = 7,
                Weight = 14,
            }
        );

        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}