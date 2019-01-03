// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Travel.Core.Controllers;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void TestWithNoTrips()
	    {
            var airport = new Airport();
            var fc = new FlightController(airport);

            var expected = $"Confiscated bags: 0 (0 items) => $0";
            Assert.That(fc.TakeOff(), Is.EqualTo(expected));
        }

        [Test]
        public void TestWithTrips()
        {
            var ivan = new Passenger("Ivan");
            var pesho = new Passenger("Pesho");
            var maria = new Passenger("Maria");
            var mario = new Passenger("Mario");
            var emil = new Passenger("Emil");
            var elena = new Passenger("Elena");

            var bag = new Bag(pesho, new IItem[] { new Toothbrush(), new Laptop()});
            pesho.Bags.Add(bag);
            var bagValue = bag.Items.Sum(x => x.Value);

            var airplane = new LightAirplane();
            airplane.AddPassenger(ivan);
            airplane.AddPassenger(pesho);
            airplane.AddPassenger(maria);
            airplane.AddPassenger(mario);
            airplane.AddPassenger(emil);
            airplane.AddPassenger(elena);

            var trip1 = new Trip("Sofia", "London", airplane);

            var airport = new Airport();
            airport.AddTrip(trip1);

            var trip2 = new Trip("Sofia", "Mascow", new LightAirplane());
            trip2.Complete();
            airport.AddTrip(trip2);

            var fc = new FlightController(airport);

            var sb = new StringBuilder();
            sb.AppendLine("SofiaLondon1:");
            sb.AppendLine($"Overbooked! Ejected Pesho");
            sb.AppendLine($"Confiscated 1 bags (${bagValue})");
            sb.AppendLine("Successfully transported 5 passengers from Sofia to London.");
            sb.AppendLine($"Confiscated bags: 1 (2 items) => ${bagValue}");

            var actual = fc.TakeOff();
            var expected = sb.ToString().TrimEnd();

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(trip1.IsCompleted, Is.True);
        }
    }
}
