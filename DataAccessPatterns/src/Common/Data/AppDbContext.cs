using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Common.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderItemDiscount> OrderItemDiscounts => Set<OrderItemDiscount>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (options.IsConfigured) return;

        // Define the path to the SQLite database file relative to the project directory
        // DataAccessPatterns\src\orders.db
        var dbPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "orders.db")
        );

        options.UseSqlite($"Data Source={dbPath}");
        options.EnableSensitiveDataLogging();
        options.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasMany(i => i.Discounts)
            .WithOne(d => d.OrderItem)
            .HasForeignKey(d => d.OrderItemId);
    }
}
