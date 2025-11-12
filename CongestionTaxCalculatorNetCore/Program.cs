using CongestionTaxCalculatorNetCore;
using CongestionTaxCalculatorNetCore.Data;
using CongestionTaxCalculatorNetCore.Models;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<TaxDbContext>()
    .UseInMemoryDatabase(Constants.Database)
    .Options;

using var context = new TaxDbContext(options);

// Seed data
SeedData.SeedGothenburg2013(context);

// Load rule from DB
var ruleEntity = context.TaxRules
    .Include(r => r.Intervals)
    .Include(r => r.TollFreeDates)
    .First(r => r.Name == Constants.GothenburgRule);

// Convert to TaxRule
var taxRule = new TaxRule
{
    DailyMax = ruleEntity.DailyMax,
    Intervals = ruleEntity.Intervals
        .Select(i => new TaxInterval { Start = i.Start, End = i.End, Fee = i.Fee })
        .ToList(),
    IsTollFreeDate = date =>
        date.Month == 7 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
        ruleEntity.TollFreeDates.Any(t => t.Date.Date == date.Date)
};

// Create calculator
var calculator = new CongestionTaxCalculator(taxRule);

// Example usage
var car = new Car();
var dates = new DateTime[]
{
    new(2013, 2, 7, 6, 23, 27),
    new(2013, 2, 7, 15, 27, 0)
};

Console.WriteLine($"Total tax: {calculator.GetTax(car, dates)} SEK");