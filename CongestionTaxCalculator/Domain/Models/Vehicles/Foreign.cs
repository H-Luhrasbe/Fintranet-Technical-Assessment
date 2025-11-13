using CongestionTaxCalculator.Domain.Interfaces;

namespace CongestionTaxCalculator.Domain.Models.Vehicles;

public class Foreign : IVehicle
{
    public string Type => Constants.VehiclesTypes.Foreign;
}