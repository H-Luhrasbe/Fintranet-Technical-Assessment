using CongestionTaxCalculatorNetCore.Contracts;
using CongestionTaxCalculatorNetCore.Models;

namespace CongestionTaxCalculatorNetCore;

/// <summary>
/// Calculates congestion tax for a vehicle using configurable tax rules.
/// </summary>
public class CongestionTaxCalculator
{
    private readonly TaxRule _taxRule;

    /// <summary>
    /// Initializes a new instance of the CongestionTaxCalculator with a specific tax rule
    /// </summary>
    /// <param name="taxRule">The TaxRule containing intervals, toll-free vehicles and dates</param>
    public CongestionTaxCalculator(TaxRule taxRule)
    {
        _taxRule = taxRule ?? throw new ArgumentNullException(nameof(taxRule));
    }

    /// <summary>
    /// Calculates total congestion tax for a vehicle on a given day
    /// </summary>
    /// <param name="vehicle">The vehicle being charged</param>
    /// <param name="dates">All timestamps the vehicle passes toll points on a single day</param>
    /// <returns>Total tax amount for the day (capped by DailyMax)</returns>
    public int GetTax(IVehicle vehicle, DateTime[] dates)
    {
        if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
        if (dates == null || dates.Length == 0) return 0;

        // Sort dates in chronological order
        var sortedDates = dates.OrderBy(d => d).ToArray();

        int totalFee = 0;
        DateTime intervalStart = sortedDates[0];
        int intervalFee = GetTollFee(intervalStart, vehicle);

        for (int i = 1; i < sortedDates.Length; i++)
        {
            var currentDate = sortedDates[i];
            int currentFee = GetTollFee(currentDate, vehicle);

            // Calculate minutes difference
            double minutes = (currentDate - intervalStart).TotalMinutes;

            if (minutes <= 60)
            {
                // Single-charge rule: take highest fee in the 60-minute window
                intervalFee = Math.Max(intervalFee, currentFee);
            }
            else
            {
                totalFee += intervalFee;
                intervalStart = currentDate;
                intervalFee = currentFee;
            }
        }

        // Add fee for last interval
        totalFee += intervalFee;

        // Apply daily maximum
        return Math.Min(totalFee, _taxRule.DailyMax);
    }

    /// <summary>
    /// Determines the toll fee for a vehicle at a specific timestamp
    /// </summary>
    private int GetTollFee(DateTime date, IVehicle vehicle)
    {
        // Toll-free vehicle or date
        if (IsTollFreeVehicle(vehicle) || IsTollFreeDate(date))
            return 0;

        var time = date.TimeOfDay;

        // Find the interval matching the timestamp
        var interval = _taxRule.Intervals
            .FirstOrDefault(i => time >= i.Start && time < i.End);

        return interval?.Fee ?? 0;
    }

    /// <summary>
    /// Determines if the vehicle is exempt from congestion tax
    /// </summary>
    private bool IsTollFreeVehicle(IVehicle vehicle)
    {
        return _taxRule.TollFreeVehicleTypes.Contains(vehicle.VehicleType);
    }

    /// <summary>
    /// Determines if the date is toll-free (weekends, July, or DB-specified holidays)
    /// </summary>
    private bool IsTollFreeDate(DateTime date)
    {
        // If domain has explicit toll-free dates, consult them first
        if (_taxRule.TollFreeDates != null && _taxRule.TollFreeDates.Any(d => d.Date == date.Date))
            return true;

        // Weekends
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            return true;

        // July (summer)
        if (date.Month == 7)
            return true;

        // fallback to optional predicate if provided
        if (_taxRule.IsTollFreeDate != null && _taxRule.IsTollFreeDate(date))
            return true;

        return false;
    }
}