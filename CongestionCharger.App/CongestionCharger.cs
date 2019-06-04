using System;
using System.Linq;

namespace CongestionCharger.App
{
    public class CongestionCharger
    {
        public Charge Charge(VehicleType type, string from, string to)
        {
            return Charge(type, DateTime.Parse(from), DateTime.Parse(to));
        }

        public Charge Charge(VehicleType type, DateTime from, DateTime to)
        {
            var span = to - from;
            var finalCharge = Enumerable.Range(0, (int)span.TotalMinutes)
                .Select(x => from.AddMinutes(x))
                .Select(x => (x.Hour, x.DayOfWeek))
                .Aggregate(new Charge(type), (charge, minute) => Calc(minute, charge));

            return finalCharge;
        }

        private static Charge Calc((int Hour, DayOfWeek DayOfWeek) minute, Charge charge)
        {
            switch (minute)
            {
                case var _ when minute.DayOfWeek == DayOfWeek.Saturday:
                    return charge;

                case var _ when minute.DayOfWeek == DayOfWeek.Sunday:
                    return charge;

                case var _ when minute.Hour < 7 || minute.Hour >= 19:
                    return charge;

                case var _ when minute.Hour < 12:
                    charge.SpanAM += TimeSpan.FromMinutes(1);
                    return charge;

                case var _ when minute.Hour >= 12:
                    charge.SpanPM += TimeSpan.FromMinutes(1);
                    return charge;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}