using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculatorNetCore.Data;

/// <summary>
/// Factory to create TaxDbContext with in-memory database
/// </summary>
public static class DbContextFactory
{
    public static TaxDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaxDbContext>()
            .UseInMemoryDatabase("TaxRulesDb")
            .Options;

        return new TaxDbContext(options);
    }
}