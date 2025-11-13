using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Emergency : IVehicle
{
    public string Type => Constants.VehiclesTypes.Emergency;
}