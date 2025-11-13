using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

public class Bus : IVehicle
{
    public string Type => Constants.VehiclesTypes.Bus;
}