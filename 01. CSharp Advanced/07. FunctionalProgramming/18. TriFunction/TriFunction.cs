using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Func<string, int, bool> isValid = (n, num) => n.ToCharArray().Select(ch =>(int)ch).Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string>firstValidName = (arr, num, func) => arr
                .FirstOrDefault(str => func(str, num));

            var result = firstValidName(names, number, isValid);

            Console.WriteLine(result);

        }
    }
}
