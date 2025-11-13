using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models;

public class DiplomatCar : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Diplomat";
}