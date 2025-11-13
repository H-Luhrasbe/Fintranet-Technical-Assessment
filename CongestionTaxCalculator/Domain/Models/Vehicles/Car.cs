using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

/// <summary>
/// Represents a normal car that is subject to congestion tax.
/// </summary>
public class Car : IVehicle
{
    public string Type => Constants.VehiclesTypes.Car;
}