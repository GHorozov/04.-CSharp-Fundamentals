using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();

            while(input != "search")
            {
                var lineParts = input.Split(new[] { ' ', '-', '+' }, StringSplitOptions.RemoveEmptyEntries);
                var name = lineParts[0];
                var number = lineParts[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, number);
                }

                phonebook[name] = number;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while(input != "stop")
            {
                var searchName = input;

                if (phonebook.ContainsKey(searchName))
                {
                    Console.WriteLine($"{searchName} -> {phonebook[searchName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchName} does not exist.");
                }

                input = Console.ReadLine();
            }        
        }
    }
}
