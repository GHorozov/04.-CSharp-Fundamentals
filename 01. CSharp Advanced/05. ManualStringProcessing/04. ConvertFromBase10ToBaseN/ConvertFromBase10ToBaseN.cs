using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBase10ToBaseN
{
    class ConvertFromBase10ToBaseN
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            var baseNumber = BigInteger.Parse(numbers[0]); //base-N to which I have to convert.
            var number = BigInteger.Parse(numbers[1]); // base 10 number to convert in base-N.
            string conversion = "";


            while (number != 0)
            {

                conversion += Convert.ToString(number % baseNumber);
                number = number / baseNumber;
            }
            var result = conversion.ToArray().Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
