using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        var people = new List<Person>();
        var products = new List<Product>();   

        try
        {
            var allPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var allProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var man in allPeople)
            {
                var manInfo = man.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var name = manInfo[0];
                var money = decimal.Parse(manInfo[1]);

                people.Add(new Person(name, money));
            }

            foreach (var product in allProducts)
            {
                var productInfo = product.Split(new[] {'='},StringSplitOptions.RemoveEmptyEntries);
                var name = productInfo[0];
                var cost = decimal.Parse(productInfo[1]);

                products.Add(new Product(name, cost));
            }

            var command = Console.ReadLine();

            while(command != "END")
            {
                var commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = commandParts[0];
                var productName = commandParts[1];

                var person = people.Where(p => p.Name == personName).FirstOrDefault();
                var product = products.Where(p => p.Name == productName).FirstOrDefault();

                person.BuyProduct(product);

                command = Console.ReadLine();
            }

            foreach (var man in people)
            {
                if(man.BagOfProduct.Count > 0)
                {
                    Console.WriteLine($"{man.Name} - {string.Join(", ", man.BagOfProduct.Select(p => p.Name))}");
                }
                else
                {
                    Console.WriteLine($"{man.Name} - Nothing bought");
                }
            }

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

