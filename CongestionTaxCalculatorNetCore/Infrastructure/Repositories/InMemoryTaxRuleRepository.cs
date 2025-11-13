using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Infrastructure.Data;
using CongestionTaxCalculatorNetCore.Infrastructure.Entities;
using CongestionTaxCalculatorNetCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Repositories;

/// <summary>
/// Simple in-memory repository implementation for testing and demo purposes.
/// Stores a predefined list of <see cref="TaxRule"/> objects.
/// </summary>
public class InMemoryTaxRuleRepository : ITaxRuleRepository
{
    private readonly TaxDbContext _dbContext;


    /// <summary>
    /// Initializes the repository with hard-coded data.
    /// </summary>
    public InMemoryTaxRuleRepository(TaxDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Returns the tax rule for the specified city (case-insensitive).
    /// </summary>
    public async Task<TaxRuleEntity?> GetRuleByCityAsync(string city) =>
        await _dbContext.TaxRules
            .Include(r => r.Rates)
            .Include(r => r.TollFreeDates)
            .FirstOrDefaultAsync(r => r.City == city);
}