namespace DatabaseTests
{
    using NUnit.Framework;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void TestConstructor_TestWithWrongLength_ShouldReturnExeption()
        {
            var arrayInput = new int[10];
            Assert.Throws<InvalidOperationException>(() => new Database(arrayInput));
        }

        [Test]
        public void TestConstructor_TestWithCorrectLenght_ReturnCollection()
        {
            var arrayInput = new int[16] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            var database = new Database(arrayInput);
            var expectedArray = arrayInput;
            Assert.That(database.Collection, Is.EqualTo(expectedArray));
        }

        [Test]
        public void TestAddMethod_TestWithLargerLenghtThanCapacity_ShouldThrowExeption()
        {
            var inputArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database(inputArray);
            int inputNumber = 1;
            Assert.Throws<InvalidOperationException>(() => database.Add(inputNumber));
        }

        [Test]
        public void TestAddMethod_TestWithCorrectNumber_ShouldAddNumber()
        {
            var inputArray = new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var database = new Database(inputArray);
            int inputNumber = 2;
            database.Add(inputNumber);
            var expectedValue = 2;
            Assert.That(database.Collection[1], Is.EqualTo(expectedValue));
        }


        [Test]
        public void TestRemoveMethod_TestWithEmptyArray_ShouldThrowExeption()
        {
            var inputArray = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            var database = new Database(inputArray);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestRemoveMethod_TestWithCorrectArray_ShouldRemoveLastElement()
        {
            var inputArray = new int[16] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            var database = new Database(inputArray);
            database.Remove();
            var expected = new int[16] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            Assert.That(database.Collection, Is.EqualTo(expected));
        }

        [Test]
        public void TestFetchMethod_TestWithArray_ShouldReturnSameArrayValues()
        {
            var inputArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            var database = new Database(inputArray);
            var expected = database.Fetch();
            Assert.That(database.Collection, Is.EqualTo(expected));
        }

        [Test]
        public void TestFetchMethod_TestWithArray_ShouldReturnDiffrentArrayValues()
        {
            var inputArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var database = new Database(inputArray);
            database.Add(1);
            var expected = database.Fetch();
            Assert.AreNotEqual(database.Collection, Is.EqualTo(expected));
        }
    }
}
