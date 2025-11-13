using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Infrastructure.Entities;

namespace CongestionTaxCalculatorNetCore.Domain.Mappers;

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
            // Populate default value for the IsTollFreeDate property
            IsTollFreeDate = date =>
                date.Month == 7 || // July
                date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday ||
                entity.TollFreeDates.Any(t => t.Date.Date == date.Date),
            TollFreeVehicleTypes = entity.TollFreeVehicles
                .Select(v => v.VehicleType)
                .ToList(),
            TollFreeDates = entity.TollFreeDates
                .Select(t => t.Date.Date)
                .ToList()
        };

        return rule;
    }
}