using CongestionTaxCalculatorNetCore.Domain.Interfaces;
using CongestionTaxCalculatorNetCore.Domain.Mappers;
using CongestionTaxCalculatorNetCore.Infrastructure.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Services;

/// <summary>
/// High-level orchestrator that selects the appropriate calculator
/// and rule based on the city and computes the congestion tax.
/// </summary>
public class TaxCalculatorService
{
    private readonly IDictionary<string, ITaxCalculator> _calculators;
    private readonly ITaxRuleRepository _ruleRepository;

    /// <summary>
    /// Initializes the tax calculator service with known calculators and a rule repository.
    /// </summary>
    /// <param name="ruleRepository">Repository that provides city-specific tax rules.</param>
    public TaxCalculatorService(ITaxRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;

        // Register available city calculators here.
        _calculators = new Dictionary<string, ITaxCalculator>(StringComparer.OrdinalIgnoreCase)
        {
            { Constants.Cities.Gothenburg, new GothenburgTaxCalculator() }
            // Future extension: { "Stockholm", new StockholmTaxCalculator() }
        };
    }

    /// <summary>
    /// Calculates congestion tax for a specific city and vehicle.
    /// </summary>
    /// <param name="city">City name (e.g., "Gothenburg").</param>
    /// <param name="vehicle">Vehicle being taxed.</param>
    /// <param name="dates">Array of timestamps representing passages.</param>
    /// <returns>The total calculated tax.</returns>
    /// <exception cref="ArgumentException">Thrown if no rule or calculator exists for the city.</exception>
    public async Task<int> CalculateTaxAsync(string city, IVehicle vehicle, DateTime[] dates)
    {
        // Query TaxRuleEntity
        var ruleEntity = await _ruleRepository.GetRuleByCityAsync(city)
                         ?? throw new ArgumentException($"No rule found for {city}");

        // Map TaxRuleEntity to TaxRule
        var rule = TaxRuleMapper.MapToDomain(ruleEntity);

        // Get the appropriate calculator
        if (!_calculators.TryGetValue(city, out var calculator))
            throw new ArgumentException($"No calculator defined for {city}");

        // Perform the calculation
        return calculator.GetTax(vehicle, dates, rule);
    }
}