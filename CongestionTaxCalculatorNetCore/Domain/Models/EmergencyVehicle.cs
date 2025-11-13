using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models;

public class EmergencyVehicle : IVehicle
{
    public string Type => "Emergency";
}