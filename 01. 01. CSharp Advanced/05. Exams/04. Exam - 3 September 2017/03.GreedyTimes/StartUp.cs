namespace _03.GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var bag = new Dictionary<string, Dictionary<string, long>>()
            {
                { "Gold", new Dictionary<string, long>() },
                { "Gem", new Dictionary<string, long>() },
                { "Cash", new Dictionary<string, long>() }
            };

            var input = Console.ReadLine()
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            var currentBagAmount = 0L;
            var allCash = 0L;
            var allGems = 0L;
            var allGold = 0L;

            for (int i = 0; i < input.Length; i += 2)
            {
                var item = input[i];
                var quantity = long.Parse(input[i + 1]);

                if ((currentBagAmount + quantity) > bagCapacity)
                {
                    continue;
                }

                allCash = bag["Cash"].Select(x => x.Value).Sum();
                allGems = bag["Gem"].Select(x => x.Value).Sum();
                allGold = bag["Gold"].Select(x => x.Value).Sum();

                if (item.ToLower().Length == 3)
                {
                    if ((allCash + quantity) > allGems)
                    {
                        continue;
                    }

                    if (!bag["Cash"].ContainsKey(item))
                    {
                        bag["Cash"][item] = 0;
                    }

                    bag["Cash"][item] += quantity;
                    currentBagAmount += quantity;
                }
                else if (item.ToLower().Length >= 4 && item.ToLower().EndsWith("gem"))
                {
                    if ((allGems + quantity) > allGold)
                    {
                        continue;
                    }

                    if (!bag["Gem"].ContainsKey(item))
                    {
                        bag["Gem"][item] = 0;
                    }

                    bag["Gem"][item] += quantity;
                    currentBagAmount += quantity;
                }
                else if (item.ToLower() == "gold")
                {
                    if (!bag["Gold"].ContainsKey(item))
                    {
                        bag["Gold"].Add(item, 0);
                    }

                    bag["Gold"][item] += quantity;
                    currentBagAmount += quantity;
                }
            }

            foreach (var resource in bag.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Sum(s => s.Value)))
            {
                var resourceTotalAmount = resource.Value.Select(x => x.Value).Sum();

                Console.WriteLine($"<{resource.Key}> ${resourceTotalAmount}");
                foreach (var item in resource.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}