using CongestionTaxCalculatorNetCore.Contracts;

namespace CongestionTaxCalculatorNetCore.Models;

public class DiplomatCar : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Diplomat";
}