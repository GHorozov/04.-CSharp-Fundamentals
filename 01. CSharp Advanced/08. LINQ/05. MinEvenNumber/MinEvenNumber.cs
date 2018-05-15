using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinEvenNumber
{
    class MinEvenNumber
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(x => x % 2 == 0)
                .ToArray();


            if (input.Any())
            {
                var result = input.Min();
                Console.WriteLine("{0:f2}", result);
            }
            else
            {
                Console.WriteLine("No match");
            }

            //II-way
            //try
            //{
            //    Console.WriteLine("{0:f2}", Console.ReadLine()
            //    .Split(' ')
            //    .Select(double.Parse)
            //    .Where(x => x % 2 == 0)
            //    .Min());
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("No match");
            //}
        }
    }
}
