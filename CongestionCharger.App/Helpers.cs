using System;
using System.Reflection;

namespace CongestionCharger.App
{
    public static class Helpers
    {
        public static decimal RoundDown(decimal d)
        {
            return Math.Floor(d * 10) / 10;
        }

        public static string WithCulture(IFormatProvider cultureInfo, FormattableString formattableString)
        {
            return formattableString.ToString(cultureInfo);
        }

        public static VehicleRate GetRate(this VehicleType vehicleType)
        {
            var typeOfRate = GetType(vehicleType);

            return (VehicleRate)Activator.CreateInstance(typeOfRate);
        }

        private static Type GetType(VehicleType type)
        {
            var attr = (ConstructableEnumAttribute)Attribute.GetCustomAttribute(ForValue(type), typeof(ConstructableEnumAttribute));

            return attr.Type;
        }

        private static MemberInfo ForValue(VehicleType type)
        {
            return typeof(VehicleType).GetField(Enum.GetName(typeof(VehicleType), type));
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ConstructableEnumAttribute : Attribute
    {
        public Type Type { get; }

        public ConstructableEnumAttribute(Type type)
        {
            Type = type;
        }
    }
}