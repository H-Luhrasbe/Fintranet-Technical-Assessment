using congestion.calculator.Contracts;

namespace congestion.calculator.Models;

public class DiplomatCar : IVehicle
{
    public bool IsTollFree => true;
    public string VehicleType => "Diplomat";
}