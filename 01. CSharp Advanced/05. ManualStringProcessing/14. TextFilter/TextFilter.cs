using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            var banWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            for (int i = 0; i < banWords.Length; i++)
            {
                var currentWord = banWords[i];

                text = text.Replace(currentWord, new string('*', currentWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}
