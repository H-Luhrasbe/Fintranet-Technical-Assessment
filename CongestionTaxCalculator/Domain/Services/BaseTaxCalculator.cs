using CongestionTaxCalculator.Domain.Interfaces;
using CongestionTaxCalculator.Domain.Models;

namespace CongestionTaxCalculator.Domain.Services;

/// <summary>
/// Abstract base class providing common functionality for city-specific tax calculators.
/// </summary>
public abstract class BaseTaxCalculator : ITaxCalculator
{
    protected TaxRule TaxRule { set; get; } = null!;

    /// <summary>
    /// Performs the actual calculation of the tax. 
    /// Must be implemented by each derived city-specific calculator.
    /// </summary>
    public abstract int GetTax(IVehicle vehicle, DateTime[] dates, TaxRule rule);


    /// <summary>
    /// Determines the toll fee for a vehicle at a specific timestamp
    /// </summary>
    protected int GetTollFee(DateTime date, IVehicle vehicle)
    {
        // Toll-free vehicle or date
        if (IsTollFreeVehicle(vehicle) || IsTollFreeDate(date))
            return 0;

        var time = date.TimeOfDay;

        // Find the rate matching the timestamp
        var rate = TaxRule.Rates
            .FirstOrDefault(i => time >= i.StartTime && time < i.EndTime);

        return rate?.Amount ?? 0;
    }

    /// <summary>
    /// Checks if the vehicle is toll-free according to the TaxRule.
    /// </summary>
    protected bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return false;

        return TaxRule.TollFreeVehicle
            .Any(v => string.Equals(v, vehicle.Type, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Checks if a specific date is toll-free based on the provided rule.
    /// </summary>
    /// <param name="date">Date to check.</param>
    /// <param name="rule">Rule containing toll-free dates.</param>
    /// <returns>True if the date is toll-free, otherwise false.</returns>
    protected bool IsTollFreeDate(DateTime date)
    {
        // If domain has explicit toll-free dates, consult them first
        if (TaxRule.TollFreeDates != null && TaxRule.TollFreeDates.Any(d => d.Date == date.Date))
            return true;

        // Weekends
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return true;

        // July (summer)
        if (date.Month == 7)
            return true;

        return false;
    }
}