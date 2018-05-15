using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Func<int,int, bool > filter = (n, d) => n <= d;
            PrintResult(number, names, filter);
             
        }

        private static void PrintResult(int number, string[] names, Func<int, int, bool> filter)
        {
            for (int i = 0; i < names.Length; i++)
            {
                var currentName = names[i].Length;
                if(filter(currentName, number))
                {
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}
