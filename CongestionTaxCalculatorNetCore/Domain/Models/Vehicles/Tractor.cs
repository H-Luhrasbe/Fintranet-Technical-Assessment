using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Tractor : IVehicle
{
    public string Type => "Tractor";
}