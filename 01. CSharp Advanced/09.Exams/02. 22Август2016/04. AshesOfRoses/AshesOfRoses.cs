using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AshesOfRoses
{
    class AshesOfRoses
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var roses = new Dictionary<string, Dictionary<string, long>>();

            while (input != "Icarus, Ignite!")
            {
                var match = Regex.Match(input, @"^Grow <([A-Z][a-z]+)> <([A-Za-z0-9]+)> (\d+)$");

                if (match.Success)
                {
                    var place = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var amount = long.Parse(match.Groups[3].Value);

                    if (!roses.ContainsKey(place))
                    {
                        roses[place] = new Dictionary<string, long>();
                    }
                    if (!roses[place].ContainsKey(color))
                    {
                        roses[place][color] = 0;
                    }

                    roses[place][color] += amount;
                }

               input = Console.ReadLine();
            }


            foreach (var region in roses.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{region.Key}");
                foreach (var color in region.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }

        }
    }
}
