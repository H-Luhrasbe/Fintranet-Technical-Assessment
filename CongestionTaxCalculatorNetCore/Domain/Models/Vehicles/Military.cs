using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models.Vehicles;

public class Military : IVehicle
{
    public string Type => "Military";
}