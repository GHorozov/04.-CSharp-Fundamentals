namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var army = new Dictionary<string, Dictionary<string, long>>();

            string input;
            while ((input = Console.ReadLine()) != "Count em all")
            {
                var lineParts = input.Split(new[] { " -> ",  }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var region = lineParts[0];
                var type = lineParts[1];
                var soldiersNumber = long.Parse(lineParts[2]);

                if (!army.ContainsKey(region))
                {
                    army[region] = new Dictionary<string, long>() { { "Green", 0L }, { "Red", 0L }, { "Black", 0L} };
                }

                army[region][type] += soldiersNumber;

                UpdateStats(army, region);
            }

            foreach (var region in army.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var item in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {item.Key} : {item.Value}");
                }
            }
        }

        private static void UpdateStats(Dictionary<string, Dictionary<string, long>> army, string regionName)
        {
            if (army[regionName]["Green"] >= 1_000_000)
            {
                var leftOver = army[regionName]["Green"] % 1_000_000;
                var mils = army[regionName]["Green"] / 1_000_000;

                army[regionName]["Green"] = leftOver;
                army[regionName]["Red"] += mils;
            }

            if (army[regionName]["Red"] >= 1_000_000)
            {
                var leftOver = army[regionName]["Red"] % 1_000_000;
                var mils = army[regionName]["Red"] / 1_000_000;

                army[regionName]["Red"] = leftOver;
                army[regionName]["Black"] += mils;
            }
        }
    }
}
