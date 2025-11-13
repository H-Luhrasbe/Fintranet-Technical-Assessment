using CongestionTaxCalculatorNetCore.Infrastructure.Data;
using CongestionTaxCalculatorNetCore.Infrastructure.Entities;

namespace CongestionTaxCalculatorNetCore.Infrastructure.SeedData;

public static class TaxDataSeeder
{
    public static void SeedGothenburg2013(TaxDbContext context)
    {
        if (context.TaxRules.Any()) return;

        var gothenburgRule = new TaxRuleEntity
        {
            City = Constants.Cities.Gothenburg,
            MaxDailyTax = 60,
            Rates =
            [
                new() { StartTime = TimeSpan.FromHours(6.0), EndTime = TimeSpan.FromHours(6.5), Amount = 8 },
                new() { StartTime = TimeSpan.FromHours(6.5), EndTime = TimeSpan.FromHours(7.0), Amount = 13 },
                new() { StartTime = TimeSpan.FromHours(7.0), EndTime = TimeSpan.FromHours(8.0), Amount = 18 },
                new() { StartTime = TimeSpan.FromHours(8.0), EndTime = TimeSpan.FromHours(8.5), Amount = 13 },
                new() { StartTime = TimeSpan.FromHours(8.5), EndTime = TimeSpan.FromHours(15.0), Amount = 8 },
                new() { StartTime = TimeSpan.FromHours(15.0), EndTime = TimeSpan.FromHours(15.5), Amount = 13 },
                new() { StartTime = TimeSpan.FromHours(15.5), EndTime = TimeSpan.FromHours(17.0), Amount = 18 },
                new() { StartTime = TimeSpan.FromHours(17.0), EndTime = TimeSpan.FromHours(18.0), Amount = 13 },
                new() { StartTime = TimeSpan.FromHours(18.0), EndTime = TimeSpan.FromHours(18.5), Amount = 8 },
            ],
            TollFreeDates =
            [
                new() { Date = new DateTime(2013, 1, 1) },
                new() { Date = new DateTime(2013, 3, 28) },
                new() { Date = new DateTime(2013, 3, 29) },
                new() { Date = new DateTime(2013, 4, 1) },
                new() { Date = new DateTime(2013, 4, 30) },
                new() { Date = new DateTime(2013, 5, 1) },
                new() { Date = new DateTime(2013, 5, 8) },
                new() { Date = new DateTime(2013, 5, 9) },
                new() { Date = new DateTime(2013, 6, 5) },
                new() { Date = new DateTime(2013, 6, 6) },
                new() { Date = new DateTime(2013, 6, 21) },
                new() { Date = new DateTime(2013, 11, 1) },
                new() { Date = new DateTime(2013, 12, 24) },
                new() { Date = new DateTime(2013, 12, 25) },
                new() { Date = new DateTime(2013, 12, 26) },
                new() { Date = new DateTime(2013, 12, 31) }
            ],
            TollFreeVehicles =
            [
                new() { VehicleType = "Motorcycle" },
                new() { VehicleType = "Tractor" },
                new() { VehicleType = "Emergency" },
                new() { VehicleType = "Diplomat" },
                new() { VehicleType = "Foreign" },
                new() { VehicleType = "Military" }
            ]
        };

        context.TaxRules.Add(gothenburgRule);
        context.SaveChanges();
    }
}