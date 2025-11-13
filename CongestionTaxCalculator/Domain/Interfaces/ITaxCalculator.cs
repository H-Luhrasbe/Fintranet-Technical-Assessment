using CongestionTaxCalculator.Domain.Models;

namespace CongestionTaxCalculator.Domain.Interfaces;

/// <summary>
/// Defines the contract for any congestion tax calculator.
/// Implementations contain city-specific logic for how the tax is computed.
/// </summary>
public interface ITaxCalculator
{
    /// <summary>
    /// Calculates the total congestion tax for a given vehicle and set of passage times.
    /// </summary>
    /// <param name="vehicle">The vehicle being taxed.</param>
    /// <param name="dates">Array of DateTimes representing each passage through the toll zone.</param>
    /// <param name="rule">Tax rule that defines rates, toll-free days, and other parameters.</param>
    /// <returns>The total congestion tax in the local currency unit.</returns>
    int GetTax(IVehicle vehicle, DateTime[] dates, TaxRule rule);
}