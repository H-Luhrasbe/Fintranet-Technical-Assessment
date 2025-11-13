namespace CongestionTaxCalculator.Infrastructure.Entities;

/// <summary>
/// Represents a city/year tax rule
/// </summary>
public class TaxRuleEntity
{
    public int Id { get; set; }
    public string City { get; set; }
    public int MaxDailyTax { get; set; } = 60;

    public List<TaxRateEntity> Rates { get; set; } = new();
    public List<TollFreeDateEntity> TollFreeDates { get; set; } = new();
    public List<TollFreeVehicleEntity> TollFreeVehicles { get; set; } = new();
}