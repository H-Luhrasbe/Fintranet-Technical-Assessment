using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models;

public class EmergencyVehicle : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Emergency";
}