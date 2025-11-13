namespace CongestionTaxCalculatorNetCore.Domain.Interfaces;

/// <summary>
/// Represents a vehicle that may be subject to congestion tax.
/// </summary>
public interface IVehicle
{
    /// <summary>
    /// Gets the type of the vehicle (for logging or debugging purposes).
    /// </summary>
    string Type { get; }
}