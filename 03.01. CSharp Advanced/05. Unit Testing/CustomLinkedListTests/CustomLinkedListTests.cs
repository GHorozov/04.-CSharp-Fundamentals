namespace CustomLinkedListTests
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;

    public class CustomLinkedListTests
    {
        private DynamicList<int> dl;

        [SetUp]
        public void InitializeList()
        {
            dl = new DynamicList<int>();
        }

        [Test]
        public void TestLinkList_TestConstructor()
        {
            Assert.That(dl.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(-10)]
        public void TestLinkList_TestAddNumber(int value)
        {
            dl.Add(value);
            Assert.That(dl.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(2)]
        [TestCase(-5)]
        [TestCase(100)]
        public void TestLinkList_RemoveAt_ToThrowExeption(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dl.RemoveAt(value));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void TestLinkList_RemoveAt(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            var expected = dl[value];
            var actual = dl.RemoveAt(value);
            
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-2)]
        [TestCase(100)]
        [TestCase(250)]
        public void TestLinkList_Remove_DoesNotFoundValue(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            var actual = dl.Remove(value);
            Assert.That(actual, Is.EqualTo(-1));
        }

        [Test]
        [TestCase(2)]
        public void TestLinkList_Remove_MustReturnValue(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            var actual = dl.Remove(value);
            var expected = 1;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(20)]
        [TestCase(int.MaxValue)]
        public void TestLinkList_IndexOf(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            var actual = dl.IndexOf(value);
            var expected = -1;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TestLinkList_IndexOf_ToReturnCorrectIndex(int value)
        {
            dl.Add(value);
            var actual = dl.IndexOf(value);
            var expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2)]
        [TestCase(-5)]
        [TestCase(3)]
        [TestCase(-10)]
        public void TestLinkList_Contains_ToReturnTrue(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            dl.Add(-5);
            dl.Add(-10);
            var actual = dl.Contains(value);
            var expected = true;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1000)]
        [TestCase(-100)]
        public void TestLinkList_Contains_ToReturnFalse(int value)
        {
            dl.Add(1);
            dl.Add(2);
            dl.Add(3);
            dl.Add(-5);
            dl.Add(-10);
            var actual = dl.Contains(value);
            var expected = false;
            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}
