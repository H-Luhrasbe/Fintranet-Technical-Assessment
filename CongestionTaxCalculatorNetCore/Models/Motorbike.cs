using congestion.calculator.Contracts;

namespace congestion.calculator.Models;

/// <summary>
/// Represents a motorbike, which is exempt from congestion tax.
/// </summary>
public class Motorbike : IVehicle
{
    public bool IsTollFree => true; // Motorbikes are exempt

    public string VehicleType => "Motorbike";
}