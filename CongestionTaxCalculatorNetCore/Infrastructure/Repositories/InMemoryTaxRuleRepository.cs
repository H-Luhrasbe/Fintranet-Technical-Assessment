using CongestionTaxCalculatorNetCore.Domain.Mappers;
using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Infrastructure.Data;
using CongestionTaxCalculatorNetCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculatorNetCore.Infrastructure.Repositories;

public class InMemoryTaxRuleRepository : ITaxRuleRepository
{
    public TaxRule GetGothenburgRule(TaxDbContext context)
    {
        var entity = context.TaxRules
            .Include(r => r.Intervals)
            .Include(r => r.TollFreeDates)
            .First(r => r.Name == Constants.GothenburgRule);

        return TaxRuleMapper.MapToDomain(entity);
    }
}