using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Infrastructure.Data;
using CongestionTaxCalculatorNetCore.Infrastructure.Entities;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Interfaces;

/// <summary>
/// Defines an interface for retrieving city-specific tax rules.
/// Could be implemented using in-memory data, a database, or external configuration.
/// </summary>
public interface ITaxRuleRepository
{
    /// <summary>
    /// Retrieves the <see cref="TaxRule"/> for the specified city.
    /// </summary>
    /// <param name="city">City name (case-insensitive).</param>
    /// <returns>Matching <see cref="TaxRule"/> instance or null if not found.</returns>
    Task<TaxRuleEntity?> GetRuleByCityAsync(string city);
}