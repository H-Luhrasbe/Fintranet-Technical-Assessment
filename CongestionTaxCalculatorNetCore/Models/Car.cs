using CongestionTaxCalculatorNetCore.Contracts;

namespace CongestionTaxCalculatorNetCore.Models;

/// <summary>
/// Represents a normal car that is subject to congestion tax.
/// </summary>
public class Car : IVehicle
{
    public bool IsTollFree => false; // Cars are not exempt

    public string VehicleType => "Car";
}