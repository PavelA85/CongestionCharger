﻿using System;
using FluentAssertions;
using Xunit;

namespace CongestionCharger.App
{
    public class CongestionChargerTests
    {
        [Fact]
        public void Test_car()
        {
            var sut = new CongestionCharger();

            var r1 = sut.Charge(VehicleType.Car, "24/04/2008 11:32", "24/04/2008 14:42");

            r1.Should().BeEquivalentTo(new
            {
                SpanAM = TimeSpan.FromMinutes(28),
                SpanPM = TimeSpan.FromMinutes(2 * 60 + 42),
                ChargeAM = 0.90m,
                ChargePM = 6.70m,
                ChargeTotal = 7.60m,
            });

            r1.ToString().Should().BeEquivalentTo(@"Charge for 0h 28m (AM rate): £0.90

Charge for 2h 42m (PM rate): £6.70

Total Charge: £7.60");
        }

        [Fact]
        public void Test_bike()
        {
            var sut = new CongestionCharger();

            var r2 = sut.Charge(VehicleType.Motobike, "24/04/2008 17:00", "24/04/2008 22:11");

            r2.Should().BeEquivalentTo(new
            {
                SpanAM = TimeSpan.FromMinutes(0),
                SpanPM = TimeSpan.FromMinutes(2 * 60),
                ChargeAM = 0m,
                ChargePM = 2m,
                ChargeTotal = 2m,
            });

            r2.ToString().Should().BeEquivalentTo(@"Charge for 0h 0m (AM rate): £0.00

Charge for 2h 0m (PM rate): £2.00

Total Charge: £2.00");
        }

        [Fact]
        public void Test_van()
        {
            var sut = new CongestionCharger();

            var r3 = sut.Charge(VehicleType.Van, "25/04/2008 10:23", "28/04/2008 09:02");

            r3.Should().BeEquivalentTo(new
            {
                SpanAM = TimeSpan.FromMinutes(3 * 60 + 39),
                SpanPM = TimeSpan.FromMinutes(7 * 60),
                ChargeAM = 7.30m,
                ChargePM = 17.50m,
                ChargeTotal = 24.80m,
            });

            r3.ToString().Should().BeEquivalentTo(@"Charge for 3h 39m (AM rate): £7.30

Charge for 7h 0m (PM rate): £17.50

Total Charge: £24.80");
        }
        [Fact]
        public void Test_bus()
        {
            var sut = new CongestionCharger();

            var r3 = sut.Charge(VehicleType.Bus, "25/04/2008 10:23", "28/04/2008 09:02");

            r3.Should().BeEquivalentTo(new
            {
                SpanAM = TimeSpan.FromMinutes(3 * 60 + 39),
                SpanPM = TimeSpan.FromMinutes(7 * 60),
                ChargeAM = 14.60m,
                ChargePM = 35m,
                ChargeTotal = 49.60m,
            });

            r3.ToString().Should().BeEquivalentTo(@"Charge for 3h 39m (AM rate): £14.60

Charge for 7h 0m (PM rate): £35.00

Total Charge: £49.60");
        }
    }
}