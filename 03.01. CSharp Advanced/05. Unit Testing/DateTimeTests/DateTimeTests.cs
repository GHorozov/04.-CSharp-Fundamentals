namespace DateTimeTests
{
    using Moq;
    using NUnit.Framework;
    using System;

    public class DateTimeTests
    {
        private IDateTime myTime;

        [SetUp]
        public void InitializeCustomeDateTime()
        {
            myTime = new CustomDateTime();
        }

        [Test]
        public void TestCustomDateTime_TimeNow()
        {
            var expected = DateTime.Now.Date;
            var actual = myTime.Now().Date;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCustomDateTime_Addday()
        {
            var testDate = new DateTime(2000, 10, 31);
            var expectedDate = new DateTime(2000, 11, 1);
            testDate = testDate.AddDays(1);
            Assert.AreEqual(expectedDate, testDate);
        }
    }
}
