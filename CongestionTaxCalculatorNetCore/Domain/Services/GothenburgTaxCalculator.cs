using CongestionTaxCalculatorNetCore.Domain.Interfaces;
using CongestionTaxCalculatorNetCore.Domain.Models;

namespace CongestionTaxCalculatorNetCore.Domain.Services;

/// <summary>
/// Tax calculator implementation for Gothenburg.
/// Contains the logic specific to Gothenburg's congestion tax rules.
/// </summary>
public class GothenburgTaxCalculator : BaseTaxCalculator
{
    /// <summary>
    /// Calculates the total congestion tax for a vehicle in Gothenburg.
    /// </summary>
    /// <remarks>
    /// - Toll-free vehicles and toll-free dates are skipped.
    /// - Tax per passage is based on time of day.
    /// - A daily maximum cap is applied at the end.
    /// </remarks>
    public override int GetTax(IVehicle vehicle, DateTime[] dates, TaxRule rule)
    {
        if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
        if (dates == null || dates.Length == 0) return 0;

        // Set BaseTaxCalculator.TaxRule
        this.TaxRule = rule;

        // Sort dates in chronological order
        var sortedDates = dates.OrderBy(d => d).ToArray();
        var totalAmount = 0;

        DateTime ruleStart = sortedDates[0];
        var ruleAmount = GetTollFee(ruleStart, vehicle);

        // Ensure we calculate in chronological order
        foreach (var date in sortedDates)
        {
            if (IsTollFreeDate(date))
                continue;

            // Find applicable rate for the time of day
            var rate = GetTollFee(date, vehicle);

            // Difference in minutes between two passage times
            var minutes = (date - ruleStart).TotalMinutes;

            if (minutes <= 60)
            {
                // Within same 60-min window: use highest fee
                ruleAmount = Math.Max(ruleAmount, rate);
            }
            else
            {
                // 60-min window passed: finalize previous window
                totalAmount += ruleAmount;
                ruleStart = date;
                ruleAmount = rate;
            }
        }

        // Add last window
        totalAmount += ruleAmount;

        // Apply daily maximum cap
        return Math.Min(totalAmount, TaxRule.MaxDailyTax);
    }
}