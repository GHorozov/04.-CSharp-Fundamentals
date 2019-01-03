namespace _01.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var args = input.Split(new[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries);

                if(args[0] == "check")
                {
                    if (dict.ContainsKey(args[1]))
                    {
                        Console.WriteLine($"{args[1]} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{args[1]} is not available!");
                    }
                    continue;
                }

                var card = args[0];
                var sport = args[1];
                var price = double.Parse(args[2]);

                if (!dict.ContainsKey(card))
                {
                    dict[card] = new Dictionary<string, double>();
                }
                if (!dict[card].ContainsKey(sport))
                {
                    dict[card][sport] = 0.0;
                }

                dict[card][sport] = price;
            }

            foreach (var card in dict.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{card.Key}:");
                foreach (var sport in card.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"    -{sport.Key} - {sport.Value:f2}");
                }
            }
        }
    }
}
