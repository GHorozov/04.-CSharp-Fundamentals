namespace ExtendedDatabaseTests
{
    using NUnit.Framework;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void TestConstructor_TestIfReturnNewPersonArray()
        {
            var database = new Database();
            var expected = new Person[5];
            Assert.That(database.Collection, Is.EqualTo(expected));
        }

        [Test]
        public void TestConstructor_ReturnNotEqualToIntArray()
        {
            var database = new Database();
            var expected = new int[5];
            Assert.AreNotEqual(database.Collection, Is.EqualTo(expected));
        }

        [Test]
        public void TestAddMethod_ReturnExeption()
        {
            var database = new Database();
            var newPerson = new Person(1, "Ivan");
            database.Add(newPerson);
            var testPerson = new Person(1, "Ivan");
            Assert.Throws<InvalidOperationException>(() => database.Add(testPerson));
        }

        [Test]
        public void TestAddMethod_AddPersonToDatabase()
        {
            var database = new Database();
            database.Add(new Person(1, "Petar"));
            var testPerson = new Person(4, "Maria");
            database.Add(testPerson);
            Assert.That(database.Collection[1], Is.EqualTo(testPerson));
        }

        [Test]
        public void TestRemoveMethod_RemoveLastElement()
        {
            var database = new Database();
            database.Add(new Person(1, "Ivan"));
            database.Remove();
            Assert.That(database.Collection[0], Is.EqualTo(null));
        }

        [Test]
        public void TestFindByUsernameMethod_CheckIfThereIsNotUsernameWithThatNameReturnExeption()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Magda"));
        }

        [Test]
        public void TestFindByUsernameMethod_CheckIfUsernameIsNullReturnExeption()
        {
            var database = new Database();
            Assert.Throws<ArgumentException>(() => database.FindByUsername(null));
        }

        [Test]
        public void TestFindByUsernameMethod_CheckCaseSensitive()
        {
            var database = new Database();
            database.Add(new Person(1, "Maria"));
            database.Add(new Person(2, "MaRiA"));
            var actualName = database.Collection[0].Username;
            var expectedName = Is.EqualTo(database.FindByUsername("Maria").Username);
            Assert.That(actualName, expectedName);
        }

        [Test]
        public void TestFindById_ReturnExeption()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void TestFindId_ReturnExeption()
        {
            var database = new Database();
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-4));
        }
    }
}
