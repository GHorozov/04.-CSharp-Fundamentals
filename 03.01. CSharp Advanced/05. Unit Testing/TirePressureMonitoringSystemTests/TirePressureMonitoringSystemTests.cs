namespace TirePressureMonitoringSystemTests
{
    using NUnit.Framework;
    using Moq;
    using System;
    using TDDMicroExercises.TirePressureMonitoringSystem;

    public class TirePressureMonitoringSystemTests
    {
        [Test]
        [TestCase(17)]
        [TestCase(21)]
        [TestCase(18.5)]
        [TestCase(19.1)]
        public void TirePressureSystem_AlarmIsOff(double value)
        {
            var alarm = new Alarm();
            Mock<ISensor> sensor = new Mock<ISensor>();
            sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(value);

            alarm.Check();
            var actual = alarm.AlarmOn;
            var expected = false;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-10)]
        [TestCase(22)]
        [TestCase(1000)]
        public void TirePressureSystem_AlarmIsOn(double value)
        {
            var alarm = new Alarm();
            Mock<ISensor> sensor = new Mock<ISensor>();
            sensor.Setup(x => x.PopNextPressurePsiValue()).Returns(value);

            alarm.Check();
            var actual = alarm.AlarmOn;
            var expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
