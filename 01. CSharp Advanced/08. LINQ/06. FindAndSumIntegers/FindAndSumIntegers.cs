using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndSumIntegers
{
    class FindAndSumIntegers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sum = input
           .Split(' ')
           .Select(w =>
           {
               long value;
               bool success = long.TryParse(w, out value);
               return new { value, success }; //Return new anonymus object.
               })
           .Where(s => s.success)
           .Select(n => n.value)//select only values 
           .ToList()
           .Sum();

            if (sum != 0)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }

        }
    }
}
