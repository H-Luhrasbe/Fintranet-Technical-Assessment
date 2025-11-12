using CongestionTaxCalculatorNetCore;
using CongestionTaxCalculatorNetCore.Data;
using CongestionTaxCalculatorNetCore.Models;

using var context = DbContextFactory.CreateInMemoryDbContext();

// Seed data
DatabaseInitializer.Initialize(context);

// Load domain TaxRule
var taxRule = TaxRuleLoader.LoadGothenburg2013Rule(context);

// Create calculator
var calculator = new CongestionTaxCalculator(taxRule);

// Example vehicle and dates
var car = new Car();
var dates = new DateTime[]
{
    new(2013, 2, 7, 6, 23, 27),
    new(2013, 2, 7, 15, 27, 0)
};

// Calculate and print
Console.WriteLine($"Total tax: {calculator.GetTax(car, dates)} SEK");