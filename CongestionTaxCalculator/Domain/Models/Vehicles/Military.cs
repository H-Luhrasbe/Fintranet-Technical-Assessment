using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

public class Military : IVehicle
{
    public string Type => Constants.VehiclesTypes.Military;
}