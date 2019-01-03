namespace HackTests
{
    using NUnit.Framework;
    using Moq;
    using System;


    public class HackTests
    {
        [TestCase(-1)]
        [TestCase(-10.2)]
        [TestCase(-100)]
        public void TestMathAbsMethodWithNegativeInput(double number)
        {
            Assert.That(Math.Abs(number), Is.Positive);
        }

        [TestCase(1)]
        [TestCase(10.1)]
        [TestCase(21)]
        public void TestMathAbsMethodWithPositiveInput(double number)
        {
            Assert.That(Math.Abs(number), Is.Positive);
        }

        [Test]
        public void TestMathFloor()
        {
            var inputNumber = 123.123;
            var expected = 123;
            Assert.That(Math.Floor(inputNumber), Is.EqualTo(expected));
        }
    }
}
