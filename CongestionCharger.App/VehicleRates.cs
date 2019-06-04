namespace CongestionCharger.App
{
    public enum VehicleType
    {
        [ConstructableEnum(typeof(CarRate))]
        Car,
        [ConstructableEnum(typeof(VanRate))]
        Van,
        [ConstructableEnum(typeof(MotobikeRate))]
        Motobike,
        [ConstructableEnum(typeof(BusRate))]
        Bus
    }

    public abstract class VehicleRate
    {
        public abstract decimal RateAM { get; }
        public abstract decimal RatePM { get; }
    }

    public class MotobikeRate : VehicleRate
    {
        public override decimal RateAM => 1m;
        public override decimal RatePM => 1m;
    }

    public class CarRate : VehicleRate
    {
        public override decimal RateAM => 2m;
        public override decimal RatePM => 2.5m;
    }

    public class VanRate : VehicleRate
    {
        public override decimal RateAM => 2m;
        public override decimal RatePM => 2.5m;
    }

    public class BusRate : VehicleRate
    {
        public override decimal RateAM => 4m;
        public override decimal RatePM => 5m;
    }
}