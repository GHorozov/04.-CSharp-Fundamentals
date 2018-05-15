using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var population = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                var lineParts = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var country = lineParts[1];
                var city = lineParts[0];
                var peopleNumber = long.Parse(lineParts[2]);

                if (!population.ContainsKey(country))
                {
                    population[country] = new Dictionary<string, long>();
                }
                if (!population[country].ContainsKey(city))
                {
                    population[country].Add(city , 0);
                }

                population[country][city] = peopleNumber;

                input = Console.ReadLine();
            }

            foreach (var country in population.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
