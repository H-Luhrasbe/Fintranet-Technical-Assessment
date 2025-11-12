namespace CongestionTaxCalculatorNetCore.Models;

/// <summary>
/// Represents all rules for congestion tax calculation for a city or year.
/// </summary>
public class TaxRule
{
    /// <summary>
    /// List of tax intervals in a day
    /// </summary>
    public List<TaxInterval> Intervals { get; set; } = new();

    /// <summary>
    /// Maximum daily fee
    /// </summary>
    public int DailyMax { get; set; } = 60;

    /// <summary>
    /// Determines if a given date is toll-free (weekend, holiday, July, etc.)
    /// </summary>
    public Func<DateTime, bool> IsTollFreeDate { get; set; }

    /// <summary>
    /// List of toll-free vehicle types for this rule
    /// </summary>
    public List<string> TollFreeVehicleTypes { get; set; } = new();
}