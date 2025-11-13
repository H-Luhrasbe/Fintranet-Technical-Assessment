using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

public class Diplomat : IVehicle
{
    public string Type => Constants.VehiclesTypes.Diplomat;
}