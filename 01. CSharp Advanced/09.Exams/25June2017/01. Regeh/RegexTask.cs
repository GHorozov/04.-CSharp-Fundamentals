using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Regeh
{
    class RegexTask
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";
            var matches = Regex.Matches(input, pattern);

            var sb = new StringBuilder();

            if (matches.Count > 0)
            {
                var numbers = new List<int>();
                var count = 1;
                foreach (Match match in matches)
                {

                    numbers.Add(int.Parse(match.Groups[count].Value));
                    count++;
                    numbers.Add(int.Parse(match.Groups[count].Value));
                    count = 1;
                }


                for (int i = 0; i < numbers.Count; i++)
                {
                    var currentNumber = numbers[i];
                    var prevNum = numbers.Take(i).Sum();

                    if ((currentNumber+prevNum) < input.Length - 1)
                    {
                        sb.Append(input[currentNumber + prevNum]);
                    }
                    else
                    {
                       sb.Append(input[(currentNumber+prevNum) - input.Length+1]);
                    }
                }
            }

            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
