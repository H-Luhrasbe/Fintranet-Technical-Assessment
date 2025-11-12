using CongestionTaxCalculatorNetCore.Models;

namespace CongestionTaxCalculatorNetCore.TaxRules;

public class Gothenburg2013Rule
{
    TaxRule getRule() => new TaxRule
    {
        DailyMax = 60,
        Intervals = new List<TaxInterval>
        {
            new TaxInterval { Start = TimeSpan.FromHours(6), End = TimeSpan.FromMinutes(6 * 60 + 29), Fee = 8 },
            new TaxInterval { Start = TimeSpan.FromMinutes(6 * 60 + 30), End = TimeSpan.FromMinutes(6 * 60 + 59), Fee = 13 },
            new TaxInterval { Start = TimeSpan.FromHours(7), End = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)), Fee = 18 },
            new TaxInterval { Start = TimeSpan.FromHours(8), End = TimeSpan.FromMinutes(14 * 60 + 59), Fee = 8 },
            new TaxInterval { Start = TimeSpan.FromMinutes(15 * 60), End = TimeSpan.FromMinutes(15 * 60 + 29), Fee = 13 },
            new TaxInterval { Start = TimeSpan.FromMinutes(15 * 60 + 30), End = TimeSpan.FromMinutes(16 * 60 + 59), Fee = 18 },
            new TaxInterval { Start = TimeSpan.FromMinutes(17 * 60), End = TimeSpan.FromMinutes(17 * 60 + 59), Fee = 13 },
            new TaxInterval { Start = TimeSpan.FromMinutes(18 * 60), End = TimeSpan.FromMinutes(18 * 60 + 29), Fee = 8 }
        },
        IsTollFreeDate = (date) =>
        {
            // Weekends
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
            // July
            if (date.Month == 7) return true;
            // Specific holidays for 2013
            int day = date.Day;
            int month = date.Month;
            if ((month == 1 && day == 1) ||
                (month == 3 && (day == 28 || day == 29)) ||
                (month == 4 && (day == 1 || day == 30)) ||
                (month == 5 && (day == 1 || day == 8 || day == 9)) ||
                (month == 6 && (day == 5 || day == 6 || day == 21)) ||
                (month == 11 && day == 1) ||
                (month == 12 && (day == 24 || day == 25 || day == 26 || day == 31)))
                return true;

            return false;
        }
    };
}