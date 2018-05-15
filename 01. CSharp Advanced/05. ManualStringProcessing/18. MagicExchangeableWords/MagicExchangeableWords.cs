using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class MagicExchangeableWords
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstWord = input[0];
            var secondWord = input[1];

            Console.WriteLine(AreWxchangebleWords(firstWord, secondWord).ToString().ToLower());

        }

        private static bool AreWxchangebleWords(string firstWord, string secondWord)
        {
            var areExchangeable = true;
            var map = new Dictionary<char, char>();
            var min = Math.Min(firstWord.Length, secondWord.Length);


            for (int i = 0; i < min; i++)
            {
                var firstChar = firstWord[i];
                var secondChar = secondWord[i];

                if (!map.ContainsKey(firstChar))
                {
                    if (!map.ContainsValue(secondChar))
                    {
                        map.Add(firstChar, secondChar);
                    }
                    else
                    {
                        areExchangeable = false;
                        break;
                    }
                }
                else
                {
                    if (map[firstChar] != secondChar)
                    {
                        areExchangeable = false;
                        break;
                    }
                }
            }
            var left = string.Empty;
            if(firstWord.Length > secondWord.Length)
            {
                left = firstWord.Substring(min); 
            }
            else
            {
                left = secondWord.Substring(min);
            }

            foreach (var symbol in left)
            {
                if(!map.ContainsKey(symbol) && !map.ContainsValue(symbol))
                {
                    areExchangeable = false;
                    break;
                }
            }

            return areExchangeable;
        }
    }
}
