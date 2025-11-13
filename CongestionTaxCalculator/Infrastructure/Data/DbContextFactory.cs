using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Infrastructure.Data;

/// <summary>
/// Factory to create TaxDbContext with in-memory database
/// </summary>
public static class DbContextFactory
{
    public static TaxDbContext CreateInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaxDbContext>()
            .UseInMemoryDatabase(Constants.ConnectionStrings.DatabaseName)
            .Options;

        return new TaxDbContext(options);
    }
}