using CongestionTaxCalculatorNetCore.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Data;

public class TaxDbContext : DbContext
{
    public DbSet<TaxRuleEntity> TaxRules { get; set; } = null!;
    public DbSet<TaxRateEntity> TaxIntervals { get; set; } = null!;
    public DbSet<TollFreeDateEntity> TollFreeDates { get; set; } = null!;
    public DbSet<TollFreeVehicleEntity> TollFreeVehicles { get; set; }

    public TaxDbContext(DbContextOptions<TaxDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxRuleEntity>()
            .HasMany(r => r.Rates)
            .WithOne(i => i.TaxRule)
            .HasForeignKey(i => i.TaxRuleEntityId);

        modelBuilder.Entity<TaxRuleEntity>()
            .HasMany(r => r.TollFreeDates)
            .WithOne(t => t.TaxRule)
            .HasForeignKey(t => t.TaxRuleEntityId);
    }
}