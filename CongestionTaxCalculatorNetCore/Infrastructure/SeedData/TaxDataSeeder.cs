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
            Name = Constants.GothenburgRule,
            DailyMax = 60,
            Intervals =
            [
                new() { Start = TimeSpan.FromHours(6.0), End = TimeSpan.FromHours(6.5), Fee = 8 },
                new() { Start = TimeSpan.FromHours(6.5), End = TimeSpan.FromHours(7.0), Fee = 13 },
                new() { Start = TimeSpan.FromHours(7.0), End = TimeSpan.FromHours(8.0), Fee = 18 },
                new() { Start = TimeSpan.FromHours(8.0), End = TimeSpan.FromHours(8.5), Fee = 13 },
                new() { Start = TimeSpan.FromHours(8.5), End = TimeSpan.FromHours(15.0), Fee = 8 },
                new() { Start = TimeSpan.FromHours(15.0), End = TimeSpan.FromHours(15.5), Fee = 13 },
                new() { Start = TimeSpan.FromHours(15.5), End = TimeSpan.FromHours(17.0), Fee = 18 },
                new() { Start = TimeSpan.FromHours(17.0), End = TimeSpan.FromHours(18.0), Fee = 13 },
                new() { Start = TimeSpan.FromHours(18.0), End = TimeSpan.FromHours(18.5), Fee = 8 },
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