using CQRSExample.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Infrastructure.Storages;

public class Store : DbContext
{
    public Store(DbContextOptions<Store> options) : base(options) { }

    public DbSet<PostEntity> Posts { get; set; }
}