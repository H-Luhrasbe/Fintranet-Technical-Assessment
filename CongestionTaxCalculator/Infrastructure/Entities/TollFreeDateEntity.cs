namespace CongestionTaxCalculator.Infrastructure.Entities;

/// <summary>
/// Represents a toll-free date stored in DB
/// </summary>
public class TollFreeDateEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TaxRuleEntityId { get; set; }
    public TaxRuleEntity TaxRule { get; set; } = null!;
}