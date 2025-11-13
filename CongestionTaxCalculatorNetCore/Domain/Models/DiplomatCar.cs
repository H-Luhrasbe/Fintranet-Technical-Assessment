using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models;

public class DiplomatCar : IVehicle
{
    public string Type => "Diplomat";
}