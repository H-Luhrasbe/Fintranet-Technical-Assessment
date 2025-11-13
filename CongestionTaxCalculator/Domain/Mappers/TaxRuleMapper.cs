using CongestionTaxCalculator.Domain.Models;
using CongestionTaxCalculator.Infrastructure.Entities;

namespace CongestionTaxCalculator.Domain.Mappers;

/// <summary>
/// Maps EF Core entities to domain objects
/// </summary>
public static class TaxRuleMapper
{
    /// <summary>
    /// Manual mapping from TaxRuleEntity to TaxRule domain model
    /// </summary>
    public static TaxRule MapToDomain(TaxRuleEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var rule = new TaxRule
        {
            MaxDailyTax = entity.MaxDailyTax,
            Rates = entity.Rates
                .Select(i => new TaxRate
                {
                    StartTime = i.StartTime,
                    EndTime = i.EndTime,
                    Amount = i.Amount
                })
                .ToList(),
            TollFreeDates = entity.TollFreeDates
                .Select(t => t.Date.Date)
                .ToList(),
            TollFreeVehicle = entity.TollFreeVehicles
                .Select(v => v.VehicleType)
                .ToList(),
        };

        return rule;
    }
}