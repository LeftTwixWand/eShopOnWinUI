using eShopOnWinUI.Domain.Orders;
using eShopOnWinUI.Domain.Products;
using eShopOnWinUI.Domain.Warehouses;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace eShopOnWinUI.Persistence;

internal sealed class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    internal DbSet<Product> Products => Set<Product>();

    internal DbSet<Warehouse> Warehouses => Set<Warehouse>();

    internal DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = "Database.db",
            };

            optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
        }
    }
}