namespace CongestionTaxCalculatorNetCore.Infrastructure.Entities;

/// <summary>
/// Represents a tax interval stored in DB
/// </summary>
public class TaxIntervalEntity
{
    public int Id { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public int Fee { get; set; }

    public int TaxRuleEntityId { get; set; }
    public TaxRuleEntity TaxRule { get; set; } = null!;
}