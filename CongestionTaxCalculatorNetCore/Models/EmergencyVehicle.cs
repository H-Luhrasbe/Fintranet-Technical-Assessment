using CongestionTaxCalculatorNetCore.Contracts;

namespace CongestionTaxCalculatorNetCore.Models;

public class EmergencyVehicle : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Emergency";
}