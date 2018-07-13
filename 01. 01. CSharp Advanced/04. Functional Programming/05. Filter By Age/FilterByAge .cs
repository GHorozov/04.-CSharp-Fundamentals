namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilterByAge
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                people.Add(currentLine[0], int.Parse(currentLine[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = FilterCondition(condition, age);
            var printer = PrintAction(format);

            foreach (var human in people)
            {
                if (filter(human.Value))
                {
                    printer(human);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> PrintAction(string format)
        {
            switch (format)
            {
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                case "name":
                    return x => Console.WriteLine($"{x.Key}");
                case "age":
                    return x => Console.WriteLine($"{x.Value}");
                default:
                    throw new Exception();
            }
        }

        private static Func<int, bool> FilterCondition(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }
    }
}
