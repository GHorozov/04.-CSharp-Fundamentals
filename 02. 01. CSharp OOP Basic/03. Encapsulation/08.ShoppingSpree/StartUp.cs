namespace _08.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();
            GetPeople(people);
            GetProducts(products);
            ShoppingResult(people, products);
            PrintResult(people);
        }

        private static void PrintResult(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private static void ShoppingResult(List<Person> people, List<Product> products)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var lineParts = command.Split();
                var personName = lineParts[0];
                var productName = lineParts[1];

                var currentPerson = people.FirstOrDefault(x => x.Name == personName);
                var currentProduct = products.FirstOrDefault(x => x.Name == productName);

                Console.WriteLine(currentPerson.BuyProduct(currentProduct));
            }
        }

        private static void GetProducts(List<Product> products)
        {
            var lineProducts = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var product in lineProducts)
            {
                var lineParts = product.Split(new string[] { "="}, StringSplitOptions.RemoveEmptyEntries);
                var name = lineParts[0];
                var cost = decimal.Parse(lineParts[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        private static void GetPeople(List<Person> people)
        {
            var linePeople = Console.ReadLine().Split(new string[] { ";"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in linePeople)
            {
                var lineParts = person.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                var name = lineParts[0];
                var money = decimal.Parse(lineParts[1]);
                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
