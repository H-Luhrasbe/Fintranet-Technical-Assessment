using CongestionTaxCalculatorNetCore.Entities;

namespace CongestionTaxCalculatorNetCore.Data;

public static class SeedData
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
                new() { Start = TimeSpan.FromHours(6), End = TimeSpan.FromMinutes(6 * 60 + 29), Fee = 8 },
                new() { Start = TimeSpan.FromMinutes(6 * 60 + 30), End = TimeSpan.FromMinutes(6 * 60 + 59), Fee = 13 },
                new() { Start = TimeSpan.FromHours(7), End = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)), Fee = 18 },
                new() { Start = TimeSpan.FromHours(8), End = TimeSpan.FromMinutes(14 * 60 + 59), Fee = 8 },
                new() { Start = TimeSpan.FromMinutes(15 * 60), End = TimeSpan.FromMinutes(15 * 60 + 29), Fee = 13 },
                new() { Start = TimeSpan.FromMinutes(15 * 60 + 30), End = TimeSpan.FromMinutes(16 * 60 + 59), Fee = 18 },
                new() { Start = TimeSpan.FromMinutes(17 * 60), End = TimeSpan.FromMinutes(17 * 60 + 59), Fee = 13 },
                new() { Start = TimeSpan.FromMinutes(18 * 60), End = TimeSpan.FromMinutes(18 * 60 + 29), Fee = 8 }
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
            ]
        };

        context.TaxRules.Add(gothenburgRule);
        context.SaveChanges();

        context.TollFreeVehicles.AddRange(
        [
            new() { VehicleType = "Motorcycle" },
            new() { VehicleType = "Tractor" },
            new() { VehicleType = "Emergency" },
            new() { VehicleType = "Diplomat" },
            new() { VehicleType = "Foreign" },
            new() { VehicleType = "Military" }
        ]);
        context.SaveChanges();
    }
}