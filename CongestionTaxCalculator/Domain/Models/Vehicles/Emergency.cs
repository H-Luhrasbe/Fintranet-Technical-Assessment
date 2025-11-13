using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

public class Emergency : IVehicle
{
    public string Type => Constants.VehiclesTypes.Emergency;
}