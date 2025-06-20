using CQRSExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Infrastructure.Storages;

public class Store : DbContext
{
    public Store(DbContextOptions<Store> options) : base(options) { }

    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProfileEntity>().HasData(
            new ProfileEntity
            {
                Id = 1,
                DisplayName = "Alice Johnson",
                Bio = "Loves photography and travel.",
                Location = "New York",
                CreatedAt = new DateTime(2023, 5, 1),
                UpdatedAt = new DateTime(2024, 6, 1)
            },
            new ProfileEntity
            {
                Id = 2,
                DisplayName = "Bob Smith",
                Bio = "Software engineer and coffee enthusiast.",
                Location = "San Francisco",
                CreatedAt = new DateTime(2022, 8, 10),
                UpdatedAt = new DateTime(2024, 4, 15)
            },
            new ProfileEntity
            {
                Id = 3,
                DisplayName = "Carol Lee",
                Bio = "Fitness coach and blogger.",
                Location = "Chicago",
                CreatedAt = new DateTime(2021, 1, 20),
                UpdatedAt = new DateTime(2024, 1, 5)
            }
        );
    }
}