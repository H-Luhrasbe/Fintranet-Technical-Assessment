using CongestionTaxCalculator;
using CongestionTaxCalculator.Domain.Models.Vehicles;
using CongestionTaxCalculator.Domain.Services;
using CongestionTaxCalculator.Infrastructure.Data;
using CongestionTaxCalculator.Infrastructure.Repositories;

using var context = DbContextFactory.CreateInMemoryDbContext();

// Seed data
DatabaseInitializer.Initialize(context);

// Loading repository
var ruleRepo = new InMemoryTaxRuleRepository(context);

// Loading calculator
var service = new TaxCalculatorService(ruleRepo);

// Example vehicle 
var car = new Car();
var motorbike = new Motorbike();

// Example dates
var dates = new DateTime[]
{
    new(2013, 2, 7, 6, 23, 27),
    new(2013, 2, 7, 15, 27, 0)
};

var carTax = await service.CalculateTaxAsync(Constants.Cities.Gothenburg, car, dates);
var motorbikeTax = await service.CalculateTaxAsync(Constants.Cities.Gothenburg, motorbike, dates);
Console.WriteLine($"Total Car Tax: {carTax} SEK");
Console.WriteLine($"Total Motorbike Tax: {motorbikeTax} SEK");