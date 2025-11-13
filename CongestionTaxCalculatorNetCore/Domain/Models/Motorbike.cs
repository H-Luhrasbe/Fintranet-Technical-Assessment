using CongestionTaxCalculatorNetCore.Domain.Interfaces;

namespace CongestionTaxCalculatorNetCore.Domain.Models;

/// <summary>
/// Represents a motorbike, which is exempt from congestion tax.
/// </summary>
public class Motorbike : IVehicle
{
    public string Type => "Motorbike";
}