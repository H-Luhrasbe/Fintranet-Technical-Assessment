namespace CongestionTaxCalculator;

/// <summary>
/// Constants are used instead of magic string
/// </summary>
public static class Constants
{
    public static class ConnectionStrings
    {
        public const string DatabaseName = "TaxRulesDb";
    }

    public static class Cities
    {
        public const string Gothenburg = "Gothenburg";
    }

    public static class VehiclesTypes
    {
        public const string Bus = "Bus";
        public const string Car = "Car";
        public const string Diplomat = "Diplomat";
        public const string Emergency = "Emergency";
        public const string Foreign = "Foreign";
        public const string Military = "Military";
        public const string Motorcycle = "Motorcycle";
    }
}