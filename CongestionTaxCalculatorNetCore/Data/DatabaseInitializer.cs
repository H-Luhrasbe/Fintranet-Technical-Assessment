namespace CongestionTaxCalculatorNetCore.Data;

/// <summary>
/// Responsible for seeding in-memory database with initial data
/// </summary>
public static class DatabaseInitializer
{
    public static void Initialize(TaxDbContext context)
    {
        SeedData.SeedGothenburg2013(context);
    }
}