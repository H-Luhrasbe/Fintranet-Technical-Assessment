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
    /// Constructor
    /// </summary>
    /// <param name="taxRule">TaxRule object containing intervals, daily max, and toll-free dates</param>
    public CongestionTaxCalculator(TaxRule taxRule)
    {
        _taxRule = taxRule ?? throw new ArgumentNullException(nameof(taxRule));
    }


    /// <summary>
    /// Calculate total congestion tax for a vehicle on a single day.
    /// </summary>
    /// <param name="vehicle">Vehicle</param>
    /// <param name="dates">All pass timestamps on the day (must be same day)</param>
    /// <returns>Total tax amount (capped at daily max)</returns>
    public int GetTax(IVehicle vehicle, DateTime[] dates)
    {
        if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
        if (vehicle.IsTollFree || dates == null || dates.Length == 0) return 0;

        // Sort timestamps ascending
        Array.Sort(dates);

        DateTime intervalStart = dates[0];
        int totalFee = 0;

        // Track the highest fee in current 60‑minute window
        int windowMaxFee = GetFeeForDate(intervalStart);

        foreach (var date in dates.Skip(1))
        {
            if (_taxRule.IsTollFreeDate(date)) continue;

            int fee = GetFeeForDate(date);
            var diff = date - intervalStart;

            if (diff.TotalMinutes <= 60)
            {
                // still within same window → update windowMaxFee if this fee is higher
                windowMaxFee = Math.Max(windowMaxFee, fee);
            }
            else
            {
                // 60+ minutes since intervalStart: close previous window, add its max fee
                totalFee += windowMaxFee;

                // start new window
                intervalStart = date;
                windowMaxFee = fee;
            }
        }

        totalFee += windowMaxFee;

        // Apply daily maximum
        return Math.Min(totalFee, _taxRule.DailyMax);
    }

    /// <summary>
    /// Gets the toll fee for a specific timestamp using the configured intervals.
    /// </summary>
    /// <param name="date">Timestamp</param>
    /// <returns>Fee in SEK</returns>
    private int GetFeeForDate(DateTime date)
    {
        TimeSpan timeOfDay = date.TimeOfDay;

        var interval = _taxRule.Intervals.FirstOrDefault(i => i.Contains(timeOfDay));
        return interval?.Fee ?? 0;
    }
}