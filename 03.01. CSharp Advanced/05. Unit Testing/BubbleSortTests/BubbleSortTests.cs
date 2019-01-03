namespace BubbleSortTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class BubbleSortTests
    {
        [Test]
        public void TestBubbleSort_ReturnCorrectlyOrderedList()
        {
            var list = new List<int>() { 1, 3, 5, 4, 2 };
            var bubble = new Bubble(list);
            var expected = new List<int>() { 1, 2, 3, 4, 5 };
            Assert.That(bubble.BubbleSort(), Is.EqualTo(expected));
        }

        [Test]
        public void TestBubbleSort_ReturnListWithCorrectorder()
        {
            var list = new List<int>() { -1, 3, 1, -5, 4, 2 };
            var bubble = new Bubble(list);
            var expected = new List<int>() { -5,-1, 1, 2, 3, 4 };
            Assert.That(bubble.BubbleSort(), Is.EqualTo(expected));
        }

        [Test]
        public void TestBibble_ToThrowExeptionWithEmptyInput()
        {
            var list = new List<int>();
            Assert.Throws<InvalidOperationException>(() => new Bubble(list));
        }
    }
}
