using System;
using System.Text;

namespace CongestionCharger.App
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var items = new[]
            {
                (VehicleType.Car, "24/04/2008 11:32", "24/04/2008 14:42"),
                (Motobike: VehicleType.Motobike, "24/04/2008 17:00", "24/04/2008 22:11"),
                (VehicleType.Van, "25/04/2008 10:23", "28/04/2008 09:02"),
            };

            var charger = new CongestionCharger();

            foreach ((VehicleType type, string from, string to) item in items)
            {
                var c = charger.Charge(item.type, item.from, item.to);

                Console.WriteLine(item);
                Console.WriteLine(c);

                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}