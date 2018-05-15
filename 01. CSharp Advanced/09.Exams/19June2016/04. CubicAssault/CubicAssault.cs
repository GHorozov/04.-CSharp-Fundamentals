using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicAssault
{
    class CubicAssault
    {
        public static int threshold = 1000000;
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stat = new Dictionary<string, Dictionary<string, long>>();
            var meteorNames = new List<string>() { "Green", "Red", "Black" };

            while (input != "Count em all")
            {
                var line = input.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var region = line[0];
                var type = line[1];
                var soldiersNumber = long.Parse(line[2]);

                if (!stat.ContainsKey(region))
                {
                    stat[region] = new Dictionary<string, long>() { { "Green", 0 }, { "Red", 0 }, { "Black", 0 } };
                }

                stat[region][type] += soldiersNumber; //Add on;y to asigned Green,Red and Black type.

                for (int i = 0; i < meteorNames.Count - 1; i++) //To meteornames.count -1,  because there is no sense to check Black meteors. 
                {
                    var nextTypeCount = stat[region][meteorNames[i]] / threshold; //If this is less than threshold return 0 else return number > 0.

                    if (nextTypeCount > 0)
                    {
                        stat[region][meteorNames[i + 1]] += nextTypeCount; //Add everything that is == theshhold 1000000 or more all number to next type meteor.
                        stat[region][meteorNames[i]] %= threshold; //Decrease current type with theshhold value.Only left is reminder above treshhold. 
                    }
                }

                input = Console.ReadLine();
            }

            var orderStat = stat
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in orderStat)
            {
                Console.WriteLine(region.Key);

                foreach (var meteor in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }

        }
    }
}
