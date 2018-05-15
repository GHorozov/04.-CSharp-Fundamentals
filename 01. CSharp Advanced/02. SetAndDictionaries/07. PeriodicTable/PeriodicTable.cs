using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(' ');

                foreach (var element in elements)
                {
                    list.Add(element);
                }
            }

            Console.WriteLine(String.Join(" ", list));
        }
    }
}
