using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBaseNToBase10
{
    class ConvertFromBaseNToBase10
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            var baseN = int.Parse(numbers[0]); //base-N to which I have to convert.
            var baseTenNumber = numbers[1].ToCharArray(); // base 10 number to convert in base-N.

            BigInteger result = new BigInteger(0);
            for (int i = baseTenNumber.Length - 1, n = 0; i >= 0; i--, n++)
            {
                BigInteger num = new BigInteger(char.GetNumericValue(baseTenNumber[n]));
                BigInteger forSum = BigInteger.Multiply(num, BigInteger.Pow(new BigInteger(baseN), i));
                result += forSum;
            }
            Console.WriteLine(result.ToString());
        }
    }
}
