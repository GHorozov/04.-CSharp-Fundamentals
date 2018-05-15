using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, @"\[[a-zA-Z]*<(\d+REGEH\d+>[a-zA-Z]*\])");

            if (matches.Count <= 0)
            {
                return;
            }

            var list = new List<int>();
            foreach (Match match in matches)
            {
                var matchRes = Regex.Match(match.Value, @"<(\d+)REGEH(\d+)>");
                list.Add(int.Parse(matchRes.Groups[1].Value));
                list.Add(int.Parse(matchRes.Groups[2].Value));
            }
            var sb = new StringBuilder();
            var sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var currentIndex = list[i];
                sum += currentIndex;
                if (i == 0)
                {
                    sb.Append(input[currentIndex]);
                }
                else
                {
                    if (sum < input.Length-1)
                    {
                        sb.Append(input[sum]);
                    }
                    else
                    {
                        if (sum > input.Length - 1)
                        {
                            sum  =  sum % input.Length - 1;
                        }
                        sb.Append(input[sum]);
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
