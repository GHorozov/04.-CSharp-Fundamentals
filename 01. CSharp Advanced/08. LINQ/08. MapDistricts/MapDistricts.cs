using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistricts
{
    class MapDistricts
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var bound = long.Parse(Console.ReadLine());

            input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var inputParts = x.Split(':'); 
                    var cityCode = inputParts[0];
                    var districtPopulation = long.Parse(inputParts[1]);
                    return new { cityCode, districtPopulation };//Select each , split on ':', take city and population, and return new anonymus object. 
                })
                .GroupBy(
                    x => x.cityCode, //Groupe all cities
                    x => x.districtPopulation, //Groupe all DistrictPopulations
                    (city, population) => new  //Create new anonymus object for each city - districtPopulation(list)
                    {
                        CityN = city, PopulationP = population.ToList()
                    })
                .Where(x => x.PopulationP.Sum() >= bound) //Filter only population sum >= bound
                .OrderByDescending(x => x.PopulationP.Sum()) //OrderByDescending by population sum
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.CityN}: {string.Join(" ", x.PopulationP.OrderByDescending(p => p).Take(5))}")); //Print city: population orderedBydescending and take 5 from list.
           
        }
    }
}
