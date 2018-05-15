using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ','\t' }, StringSplitOptions.RemoveEmptyEntries);

            var totalResult = 0d;
            for (int i = 0; i < input.Length; i++)
            {
                var currentString = input[i];
                var firstLetter = currentString[0];
                var lastLetter = currentString[currentString.Length - 1];
                var number = long.Parse(currentString.Substring(1, currentString.Length - 2));

                var currentResult = 0d;

                if (char.IsUpper(firstLetter))
                {
                    var letterPlace = (double)(firstLetter) - 64.00;
                    currentResult += (number / letterPlace);
                }
                else
                {

                    var letterPlace = (double)(firstLetter)- 96.00;
                    currentResult += (number * letterPlace);
                }


                if (char.IsUpper(lastLetter))
                {
                    var letterPlace = (double)(lastLetter) - 64.00;              
                    totalResult += (currentResult - letterPlace);
                }
                else
                {
                    var letterPlace = (double)(lastLetter) - 96.00;
                    totalResult += (currentResult + letterPlace);
                }
            }

            Console.WriteLine($"{totalResult:f2}");
        }
    }
}
