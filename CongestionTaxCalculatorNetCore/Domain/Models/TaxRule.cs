namespace CongestionTaxCalculatorNetCore.Domain.Models;

/// <summary>
/// Domain model for tax rules used by the calculator.
/// </summary>
public class TaxRule
{
    /// <summary>
    /// Maximum fee charged per day.
    /// </summary>
    public int MaxDailyTax { get; set; } = 60;

    /// <summary>
    /// List of tax intervals for a day.
    /// </summary>
    public List<TaxRate> Rates { get; set; } = new();

    /// <summary>
    /// List of vehicle type names that are toll-free under this rule.
    /// </summary>
    public List<string> TollFreeVehicleTypes { get; set; } = new();

    /// <summary>
    /// Toll-free dates specific to this tax rule (e.g., holidays).
    /// Only the Date portion is significant (time is ignored).
    /// </summary>
    public List<DateTime> TollFreeDates { get; set; } = new();

    /// <summary>
    /// Predicate used to determine if a given date is toll-free.
    /// This can still be used for additional programmatic rules,
    /// but the domain TollFreeDates list is the primary source of truth.
    /// </summary>
    public Func<DateTime, bool>? IsTollFreeDate { get; set; }
}