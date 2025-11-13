namespace CongestionTaxCalculatorNetCore.Domain.Interfaces;

/// <summary>
/// Represents a vehicle that may be subject to congestion tax.
/// </summary>
public interface IVehicle
{
    /// <summary>
    /// Gets whether the vehicle is exempt from toll fees.
    /// </summary>
    bool IsTollFree { get; }

    /// <summary>
    /// Gets the type of the vehicle (for logging or debugging purposes).
    /// </summary>
    string VehicleType { get; }
}