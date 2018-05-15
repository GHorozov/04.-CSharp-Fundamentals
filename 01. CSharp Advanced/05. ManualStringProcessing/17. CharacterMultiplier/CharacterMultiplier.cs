using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var first = input[0];
            var second = input[1];

            int sum = SumAllChars(first, second);

            Console.WriteLine(sum);
        }

        private static int SumAllChars(string first, string second)
        {
            var min = Math.Min(first.Length, second.Length);
            var sum = 0;
            for (int i = 0; i < min; i++)
            {
                sum += first[i] * second[i];
            }

            if (first.Length != second.Length)
            {
                string longer = first.Length > second.Length ? longer = first : longer = second;

                var secondSum = longer.Skip(min).Sum(x => x);

                sum += secondSum;
            }

            return sum;
        }
    }
}
