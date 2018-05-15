using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedNumbers
{
    class BoundedNumbers
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var sequance = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var result = sequance.Where(n => n >= bounds.Min() && n <= bounds.Max()).ToList();

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
