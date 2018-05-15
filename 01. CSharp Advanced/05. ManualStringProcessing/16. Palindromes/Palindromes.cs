using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new[] {',', '.', ' ', '?', '!'},StringSplitOptions.RemoveEmptyEntries);
            var list = new SortedSet<string>();
            var leftPart = string.Empty;
            var rigthPart = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                var currentWord = text[i];
                if (currentWord.Length % 2 == 0)
                {
                    leftPart = currentWord.Substring(0, currentWord.Length / 2);
                    rigthPart = currentWord.Substring(currentWord.Length / 2);
                }
                else
                {
                    leftPart = currentWord.Substring(0, currentWord.Length / 2);
                    rigthPart = currentWord.Substring(currentWord.Length / 2+1);
                }

                var temp = rigthPart.ToString().ToCharArray();
                var rightSide = string.Empty;
                for (int k = temp.Length - 1; k >= 0; k--)
                {
                    rightSide += temp[k];
                }

                if(leftPart == rightSide)
                {
                    list.Add(currentWord);
                }
            }

            Console.WriteLine($"[{string.Join(", ", list)}]");

        }
    }
}
