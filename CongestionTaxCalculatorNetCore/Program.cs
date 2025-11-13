using CongestionTaxCalculatorNetCore;
using CongestionTaxCalculatorNetCore.Domain.Models;
using CongestionTaxCalculatorNetCore.Domain.Services;
using CongestionTaxCalculatorNetCore.Infrastructure.Data;
using CongestionTaxCalculatorNetCore.Infrastructure.Repositories;

using var context = DbContextFactory.CreateInMemoryDbContext();

// Seed data
DatabaseInitializer.Initialize(context);

// Loading repository
var ruleRepo = new InMemoryTaxRuleRepository(context);

// Loading calculator
var service = new TaxCalculatorService(ruleRepo);

// Example vehicle 
var vehicle = new Car();

// Example dates
var passageTimes = new DateTime[]
{
    new(2013, 2, 7, 6, 23, 27),
    new(2013, 2, 7, 15, 27, 0)
};

var tax = await service.CalculateTaxAsync(Constants.Cities.Gothenburg, vehicle, passageTimes);
Console.WriteLine($"Total Tax: {tax} SEK");

/*
// Load domain TaxRule
var taxRule = ruleRepo.GetGothenburgRule(context);

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

*/