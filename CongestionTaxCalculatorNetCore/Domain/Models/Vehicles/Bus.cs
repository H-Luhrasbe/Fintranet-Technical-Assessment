using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Bus : IVehicle
{
    public string Type => Constants.VehiclesTypes.Bus;
}