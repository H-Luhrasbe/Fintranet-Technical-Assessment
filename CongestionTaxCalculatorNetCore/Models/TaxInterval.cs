namespace CongestionTaxCalculatorNetCore.Models;

/// <summary>
/// Represents a single congestion tax interval with a start time, end time, and fee.
/// </summary>
public class TaxInterval
{
    /// <summary>
    /// Start of the interval (inclusive)
    /// </summary>
    public TimeSpan Start { get; set; }

    /// <summary>
    /// End of the interval (inclusive)
    /// </summary>
    public TimeSpan End { get; set; }

    /// <summary>
    /// Fee for this interval
    /// </summary>
    public int Fee { get; set; }

    /// <summary>
    /// Checks if a given time falls inside this interval
    /// </summary>
    /// <param name="time">Time to check</param>
    /// <returns>True if inside the interval</returns>
    public bool Contains(TimeSpan time)
    {
        return time >= Start && time <= End;
    }
}