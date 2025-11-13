namespace CongestionTaxCalculatorNetCore.Domain.Models;

/// <summary>
/// Represents a single congestion tax rate with a start time, end time, and amount.
/// </summary>
public class TaxRate
{
    /// <summary>
    /// Start of the rate (inclusive)
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    /// End of the rate (inclusive)
    /// </summary>
    public TimeSpan EndTime { get; set; }

    /// <summary>
    /// Fee for this rate
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Checks if a given time falls inside this rate
    /// </summary>
    /// <param name="time">Time to check</param>
    /// <returns>True if inside the rate</returns>
    public bool Contains(TimeSpan time)
    {
        return time >= StartTime && time <= EndTime;
    }
}