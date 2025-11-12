using System;
using congestion.calculator;
public class CongestionTaxCalculator
{

    /// <summary>
    /// Calculate the total toll fee for one day
    /// </summary>
    /// <param name="vehicle">the vehicle</param>
    /// <param name="dates">date and time of all passes on one day</param>
    /// <returns>the total congestion tax for that day</returns>
    public int GetTax(Vehicle vehicle, DateTime[] dates)
    {
        if (dates == null || dates.Length == 0) return 0;

        DateTime intervalStart = dates[0];
        int totalFee = 0;

        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            TimeSpan diff = date - intervalStart;
            double minutes = diff.TotalMinutes;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
                intervalStart = date; // important: reset interval start after 60 min
            }
        }

        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        if (vehicle == null) return false;
        String vehicleType = vehicle.GetVehicleType();
        return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
               vehicleType.Equals(TollFreeVehicles.Military.ToString());
    }

    public int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;
        
        int totalMinutes = date.Hour * 60 + date.Minute;

        if (totalMinutes >= 360 && totalMinutes <= 389) return 8;   // 06:00–06:29
        if (totalMinutes >= 390 && totalMinutes <= 419) return 13;  // 06:30–06:59
        if (totalMinutes >= 420 && totalMinutes <= 479) return 18;  // 07:00–07:59
        if (totalMinutes >= 480 && totalMinutes <= 509) return 13;  // 08:00–08:29
        if (totalMinutes >= 510 && totalMinutes <= 899) return 8;   // 08:30–14:59
        if (totalMinutes >= 900 && totalMinutes <= 929) return 13;  // 15:00–15:29
        if (totalMinutes >= 930 && totalMinutes <= 1019) return 18; // 15:30–16:59
        if (totalMinutes >= 1020 && totalMinutes <= 1079) return 13; // 17:00–17:59
        if (totalMinutes >= 1080 && totalMinutes <= 1109) return 8;  // 18:00–18:29

        return 0; // all other times
    }

    private Boolean IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    private enum TollFreeVehicles
    {
        Motorcycle = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5
    }
}