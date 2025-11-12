using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculatorNetCore.Entities;

/// <summary>
/// Represents a vehicle type that is exempt from congestion tax
/// </summary>
public class TollFreeVehicleEntity
{
    [Key] public int Id { get; set; }

    /// <summary>
    /// Vehicle type name (e.g., "Motorcycle", "Diplomat")
    /// </summary>
    public string VehicleType { get; set; }
}