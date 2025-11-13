namespace CongestionTaxCalculatorNetCore.Infrastructure.Entities;

/// <summary>
/// Represents a city/year tax rule
/// </summary>
public class TaxRuleEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "DefaultCity_2013";
    public int DailyMax { get; set; } = 60;

    public List<TaxIntervalEntity> Intervals { get; set; } = new();
    public List<TollFreeDateEntity> TollFreeDates { get; set; } = new();
    public List<TollFreeVehicleEntity> TollFreeVehicles { get; set; } = new();
}