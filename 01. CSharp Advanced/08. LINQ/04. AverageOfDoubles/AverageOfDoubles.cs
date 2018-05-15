using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageOfDoubles
{
    class AverageOfDoubles
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Average();

            Console.WriteLine("{0:f2}", sequance);

        }
    }
}
