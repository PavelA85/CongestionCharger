using System;

namespace CongestionCharger.App
{
    public static class Helpers
    {
        public static VehicleRate GetRate(VehicleType type)
        {
            var ns = typeof(VehicleType).Namespace;
            var typeName = $"{ns}.{type}Rate";

            return (VehicleRate)Activator.CreateInstance(Type.GetType(typeName));
        }

        public static decimal RoundDown(decimal d)
        {
            return Math.Floor(d * 10) / 10;
        }

        public static string WithCulture(IFormatProvider cultureInfo, FormattableString formattableString)
        {
            return formattableString.ToString(cultureInfo);
        }
    }
}