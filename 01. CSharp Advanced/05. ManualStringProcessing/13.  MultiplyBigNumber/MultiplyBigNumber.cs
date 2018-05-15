using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            var numberOne = Console.ReadLine().TrimStart('0');// trim leading zeros.
            var numberTwo = int.Parse(Console.ReadLine());

            if (numberOne == "0" || numberTwo == 0 || numberOne == "")//check if input is string"0" , 0 or string.Empty.
            {
                Console.WriteLine("0"); return;
            }

            var sb = new StringBuilder();
            var product = 0;
            var reminder = 0;
            var numberInMind = 0;
            for (int i = numberOne.Length - 1; i >= 0; i--)
            {
                var currentNum = int.Parse(numberOne[i].ToString());
                product = (currentNum * numberTwo) + numberInMind;
                numberInMind = product / 10;
                reminder = product % 10;
                sb.Append(reminder);
                if (i == 0 && numberInMind != 0)
                {
                    sb.Append(numberInMind);
                }


            }

            var result = sb.ToString().ToCharArray();
            Array.Reverse(result);

            Console.WriteLine(result);

        }
    }
}
