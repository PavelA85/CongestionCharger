using System;
using System.Globalization;

namespace CongestionCharger.App
{
    public class Charge
    {
        private const decimal BikeRate = 1m;
        private const decimal CarRateAM = 2m;
        private const decimal CarRatePM = 2.5m;

        private const decimal BikePerMinute = BikeRate / 60;
        private const decimal VehiclePerMinuteAM = CarRateAM / 60;
        private const decimal VehiclePerMinutePM = CarRatePM / 60;

        private readonly VehicleType _vehicle;

        public TimeSpan SpanAM { get; set; }
        public TimeSpan SpanPM { get; set; }

        public decimal ChargeAM => RoundDown((int) SpanAM.TotalMinutes * RateAm());
        public decimal ChargePM => RoundDown((int) SpanPM.TotalMinutes * RatePm());
        public decimal ChargeTotal => ChargeAM + ChargePM;

        public Charge(VehicleType vehicle)
        {
            _vehicle = vehicle;
        }

        public override string ToString()
        {
            return WithCulture(CultureInfo.GetCultureInfo("en-GB"),
                $@"Charge for {(int) SpanAM.TotalHours}h {SpanAM.Minutes}m (AM rate): {ChargeAM:C2}

Charge for {(int) SpanPM.TotalHours}h {SpanPM.Minutes}m (PM rate): {ChargePM:C2}

Total Charge: {ChargeTotal:C2}");
        }

        private decimal RateAm()
        {
            switch (_vehicle)
            {
                case VehicleType.Car:
                case VehicleType.Van:
                    return VehiclePerMinuteAM;
                case VehicleType.Motobike:
                    return BikePerMinute;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private decimal RatePm()
        {
            switch (_vehicle)
            {
                case VehicleType.Car:
                case VehicleType.Van:
                    return VehiclePerMinutePM;
                case VehicleType.Motobike:
                    return BikePerMinute;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static decimal RoundDown(decimal d)
        {
            return Math.Floor(d * 10) / 10;
        }


        private static string WithCulture(IFormatProvider cultureInfo, FormattableString formattableString)
        {
            return formattableString.ToString(cultureInfo);
        }
    }
}