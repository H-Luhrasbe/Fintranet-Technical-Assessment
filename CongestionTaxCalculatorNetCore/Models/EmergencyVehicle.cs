using congestion.calculator.Contracts;

namespace congestion.calculator.Models;

public class EmergencyVehicle : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Emergency";
}