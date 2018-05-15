using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTwo
{
    class TakeTwo
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var result = sequance.Where(x => x <= 20 && x >= 10).Distinct().Take(2).ToArray();

            if (result.Any())
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
