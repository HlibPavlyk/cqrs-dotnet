using CQRSExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Infrastructure.Storages;

// Database for write operations, using Entity Framework Core
public class Store : DbContext
{
    public Store(DbContextOptions<Store> options) : base(options) { }

    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
}