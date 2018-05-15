using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperStrings
{
    class UpperStrings
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine().Split(' ');

            sequance
                .Select(x => x.ToUpper())
                .ToList()
                .ForEach(w => Console.Write(w + " "));
        }
    }
}
