using System;
using System.Globalization;

namespace CongestionCharger.App
{
    public class Charge
    {
        private readonly VehicleRate _rate;

        public TimeSpan SpanAM { get; set; }
        public TimeSpan SpanPM { get; set; }

        public decimal ChargeAM => Helpers.RoundDown((decimal)SpanAM.TotalHours * _rate.RateAM);
        public decimal ChargePM => Helpers.RoundDown((decimal)SpanPM.TotalHours * _rate.RatePM);
        public decimal ChargeTotal => ChargeAM + ChargePM;

        public Charge(VehicleType type)
        {
            _rate = Helpers.GetRate(type);
        }

        public override string ToString()
        {
            return Helpers.WithCulture(CultureInfo.GetCultureInfo("en-GB"),
                $@"Charge for {(int)SpanAM.TotalHours}h {SpanAM.Minutes}m (AM rate): {ChargeAM:C2}

Charge for {(int)SpanPM.TotalHours}h {SpanPM.Minutes}m (PM rate): {ChargePM:C2}

Total Charge: {ChargeTotal:C2}");
        }
    }
}