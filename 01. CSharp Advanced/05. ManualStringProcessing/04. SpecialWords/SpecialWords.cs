using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialWords
{
    class SpecialWords
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, int>();
            var specialWords = Console.ReadLine().Split(' ');
            var text = Console.ReadLine().Split(new[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ', '\'', }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < specialWords.Length; i++)
            {
                var count = 0;
                var currentWord = specialWords[i];
                for (int  j= 0;j < text.Length;j++)
                {
                    if(currentWord == text[j])
                    {
                        count++;
                    }
                }
                result[currentWord] = count;
            }

            foreach (var word in result)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        
        }
    }
}
