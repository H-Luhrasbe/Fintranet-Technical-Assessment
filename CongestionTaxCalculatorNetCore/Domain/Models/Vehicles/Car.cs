using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

/// <summary>
/// Represents a normal car that is subject to congestion tax.
/// </summary>
public class Car : IVehicle
{
    public string Type => Constants.VehiclesTypes.Car;
}