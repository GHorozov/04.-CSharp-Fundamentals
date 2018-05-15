using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();
            while (input != "Over!")
            {
                var line = input;
                var mLength = int.Parse(Console.ReadLine());

                var isValid = Regex.IsMatch(line, @"(^\d+)([a-zA-Z]+)([^a-zA-Z]*$)");
                var match = Regex.Match(line, @"(^\d+)([a-zA-Z]+)([^a-zA-Z]*$)");

                if (isValid && match.Groups[2].Value.Length == mLength)
                {
                    var leftDigits = CheckLeftDigit(match.Groups[1].Value);
                    var rightDigits = CheckLeftDigit(match.Groups[3].Value);


                    sb.Append(match.Groups[2].Value + " == ");

                    for (int i = 0; i < leftDigits.Count; i++)
                    {
                        if (leftDigits[i] >= 0 && leftDigits[i] < match.Groups[2].Value.Length)
                        {
                            sb.Append(match.Groups[2].Value[leftDigits[i]]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    for (int i = 0; i < rightDigits.Count; i++)
                    {
                        var currentDigit = rightDigits[i];
                        var code = match.Groups[2].Value;

                        if (currentDigit >= 0 && currentDigit < match.Groups[2].Value.Length)
                        {
                            sb.Append(code[currentDigit]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    sb.Append(Environment.NewLine);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sb);
        }

        private static List<int> CheckLeftDigit(string value)
        {
            var result = new List<int>();
            for (int i = 0; i < value.Length; i++)
            {
                var currentSymbol = 0;
                var isDigit = int.TryParse(value[i].ToString(), out currentSymbol);

                if (isDigit)
                {
                    result.Add(currentSymbol);
                }
            }
           
            return result;
        }
    }
}
