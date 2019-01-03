namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void Test1ValidateVehicleModel()
        {
            try
            {
                var vehicle = new Revenger("", 111, 12, 123, 123, 123, new VehicleAssembler());
            }
            catch (Exception ex)
            {
                var expected = "Model cannot be null or white space!";
                var actual = ex.Message;

                Assert.That(actual, Is.EqualTo(expected));
            }

        }

        [Test]
        public void Test2()
        {
            var vehicle = new Revenger("Pesho", 111, 12, 123, 123, 123, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("TestPart1",12, 12, 12));
            vehicle.AddShellPart(new ShellPart("TestPart2", 2, 2, 2));
            vehicle.AddEndurancePart(new EndurancePart("TestPart3", 1, 1, 1));

            var actual = vehicle.Parts.Count();
            var expected = 3;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            var vehicle = new Revenger("Pesho", 111, 12, 123, 123, 123, new VehicleAssembler());

            vehicle.AddArsenalPart(new ArsenalPart("TestPart1", 12, 12, 12));
            vehicle.AddShellPart(new ShellPart("TestPart2", 2, 2, 2));
            vehicle.AddEndurancePart(new EndurancePart("TestPart3", 1, 1, 1));

            var actual = vehicle.ToString();
            var expected = @"Revenger - Pesho
Total Weight: 126.000
Total Price: 27.000
Attack: 135
Defense: 125
HitPoints: 124
Parts: TestPart1, TestPart2, TestPart3";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}