using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }

                people[name] = age;
            }

            var condition = Console.ReadLine();
            var SecondAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int,bool> test = GreateTest(condition, SecondAge);
            Action<KeyValuePair<string, int>> printer= CreatePrinter(format);

            InvokePrinter(people, test, printer);
    }

        private static void InvokePrinter(Dictionary<string, int> people, Func<int, bool> test, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (test(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Func<int, bool> GreateTest(string condition, int age)
        {
            if(condition == "older")
            {
                return n => n >= age;
            }
            else
            {
                return n => n < age;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                case "name":
                    return p => Console.WriteLine($"{p.Key}");
                case "age":
                    return p => Console.WriteLine($"{p.Value}");
                default:
                    return null;
            }
        }
    }
}
