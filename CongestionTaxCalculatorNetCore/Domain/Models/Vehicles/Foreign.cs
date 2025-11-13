using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Foreign : IVehicle
{
    public string Type => "Foreign";
}