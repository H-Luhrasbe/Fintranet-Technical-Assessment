using CongestionTaxCalculatorNetCore.Infrastructure.SeedData;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Data;

/// <summary>
/// Responsible for seeding in-memory database with initial data
/// </summary>
public static class DatabaseInitializer
{
    public static void Initialize(TaxDbContext context)
    {
        TaxDataSeeder.SeedGothenburg2013(context);
    }
}