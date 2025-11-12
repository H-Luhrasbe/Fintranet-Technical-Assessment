using CongestionTaxCalculatorNetCore.Data;
using CongestionTaxCalculatorNetCore.Mappers;
using CongestionTaxCalculatorNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculatorNetCore;

/// <summary>
/// Responsible for loading TaxRule from database and mapping to domain object
/// </summary>
public static class TaxRuleLoader
{
    public static TaxRule LoadGothenburg2013Rule(TaxDbContext context)
    {
        var entity = context.TaxRules
            .Include(r => r.Intervals)
            .Include(r => r.TollFreeDates)
            .First(r => r.Name == Constants.GothenburgRule);

        return TaxRuleMapper.MapToDomain(entity);
    }
}