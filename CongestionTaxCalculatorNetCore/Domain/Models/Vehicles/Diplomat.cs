using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Diplomat : IVehicle
{
    public string Type => Constants.VehiclesTypes.Diplomat;
}