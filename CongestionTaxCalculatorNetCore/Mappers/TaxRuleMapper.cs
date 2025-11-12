using CongestionTaxCalculatorNetCore.Entities;
using CongestionTaxCalculatorNetCore.Models;

namespace CongestionTaxCalculatorNetCore.Mappers;

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

        return new TaxRule
        {
            DailyMax = entity.DailyMax,
            Intervals = entity.Intervals
                .Select(i => new TaxInterval
                {
                    Start = i.Start,
                    End = i.End,
                    Fee = i.Fee
                })
                .ToList(),
            IsTollFreeDate = date =>
                date.Month == 7 || // July
                date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                entity.TollFreeDates.Any(t => t.Date.Date == date.Date)
        };
    }
}