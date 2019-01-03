namespace IteratorTestTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class IteratorTestTests
    {

        [Test]
        public void TestConstructor_AddCorrectList()
        {
            var list = new List<string>() { "Ivan", "Georgi"}; 
            var listIterator = new ListIterator(list);
            var expected = new List<string>() { "Ivan", "Georgi"};
            Assert.That(listIterator.Collection, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructor_ToReturnExeption()
        {
            var list = new List<string>() { "Ivan", "Georgi", null };
            Assert.Throws<ArgumentNullException>(() => new ListIterator(list));
        }

        [Test]
        public void TestHasNext_ToReturnFalse()
        {
            var list = new List<string>() { "1"};
            var listIterator = new ListIterator(list);
            Assert.That(listIterator.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void TestHasNext_ToReturnTrue()
        {
            var list = new List<string>() { "1", "2", "3"};
            var listIterator = new ListIterator(list);
            Assert.That(listIterator.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void TestMove_ExpextIndexToIncreaseWithOne()
        {
            var list = new List<string>() { "1", "2", "3" };
            var listIterator = new ListIterator(list);
            listIterator.Move();
            var expected = 1;
            Assert.That(listIterator.Index, Is.EqualTo(expected));
        }

        [Test]
        public void TestMove_ToReturnTrue()
        {
            var list = new List<string>() { "1", "2", "3" };
            var listIterator = new ListIterator(list);
            Assert.That(listIterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void TestMove_ToReturnFalse()
        {
            var list = new List<string>() { "1" };
            var listIterator = new ListIterator(list);
            Assert.That(listIterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void TestPrint_ToThrowExeption()
        {
            var list = new List<string>();
            var listIterator = new ListIterator(list);
            Assert.Throws<InvalidOperationException>(() => listIterator.Print());
        }
    }
}
