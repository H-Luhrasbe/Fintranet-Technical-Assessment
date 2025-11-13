namespace CongestionTaxCalculator.Infrastructure.Entities;

/// <summary>
/// Represents a tax rate stored in DB
/// </summary>
public class TaxRateEntity
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Amount { get; set; }

    public int TaxRuleEntityId { get; set; }
    public TaxRuleEntity TaxRule { get; set; } = null!;
}