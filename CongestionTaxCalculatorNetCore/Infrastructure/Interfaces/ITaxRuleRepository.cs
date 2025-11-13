using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Infrastructure.Data;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Interfaces;

public interface ITaxRuleRepository
{
    TaxRule GetGothenburgRule(TaxDbContext context);
}