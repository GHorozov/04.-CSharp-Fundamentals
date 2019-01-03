namespace IntegrationTests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class IntegrationTests
    {
        private Category firstCategory;
        private Category secondCategory;
        private Category thirdCategory;
        private User firstUser;
        private User secondUser;
        private Repository repository;


        [Test]
        public void TestCategory_AddCategory()
        {
            var mainCategory = new Category("One");
            var childCategory = new Category("Two");
            mainCategory.AssignToCategory(childCategory);
            Assert.That(mainCategory.Categories, Contains.Item(childCategory));
        }

        [Test]
        public void TestCategory_RemoveCategory()
        {
            var mainCategory = new Category("One");
            var childCategory = new Category("Two");
            mainCategory.AssignToCategory(childCategory);
            mainCategory.RemoveCategory(childCategory);
            Assert.That(mainCategory.Categories, Is.Empty);
        }

        [Test]
        public void TestCategory_AddUser()
        {
            var mainCategory = new Category("One");
            var childCategory = new Category("Two");
            mainCategory.AssignToCategory(childCategory);
            var user = new User("Ivan");
            mainCategory.AssignToUsers(user);
            Assert.That(mainCategory.Users, Contains.Item(user));
        }

        [Test]
        public void TestUser_AddCategory()
        {
            var user = new User("Maria");
            var category = new Category("One");
            user.AssignCategory(category);
            Assert.That(user.Categories, Contains.Item(category));
        }

        [SetUp]
        public void InitiateTest()
        {
            firstCategory = new Category("First");
            secondCategory = new Category("Second");
            thirdCategory = new Category("Third");

            firstUser = new User("User1");
            secondUser = new User("User2");

            repository = new Repository();
        }

        [Test]
        public void TestRepository_AddCategory()
        {
            repository.AddCategory(firstCategory);
            Assert.That(repository.Categories, Contains.Item(firstCategory));
        }

        [Test]
        public void TestRepository_AddUser()
        {
            repository.AddUser(firstUser);
            Assert.That(repository.Users, Contains.Item(firstUser));
        }

        [Test]
        public void TestRepository_RemoveCategory()
        {
            repository.AddCategory(firstCategory);
            repository.RemoveCategory(firstCategory);
            Assert.That(repository.Categories, Does.Not.Contain(firstCategory));
        }

        [Test]
        public void TestRepository_AddChildToParentCategoryMethod()
        {
            repository.AddCategory(firstCategory);
            repository.AddCategory(secondCategory);
            repository.AddChildToParentCategory(firstCategory, secondCategory);
            var actual = repository.Categories.First().Categories;
            Assert.That(actual, Contains.Item(secondCategory));
        }

        [Test]
        public void TestRepository_AddUserToCategory_CheckUser()
        {
            repository.AddCategory(firstCategory);
            repository.AddUser(firstUser);
            repository.AddUserToCategory(firstCategory, firstUser);
            Assert.That(repository.Categories.First().Users, Contains.Item(firstUser));
        }

        [Test]
        public void TestRepository_AddUserToCategory_CheckCategory()
        {
            repository.AddCategory(firstCategory);
            repository.AddUser(firstUser);
            repository.AddUserToCategory(firstCategory, firstUser);
            Assert.That(repository.Users.First().Categories, Contains.Item(firstCategory));
        }
    }
}
