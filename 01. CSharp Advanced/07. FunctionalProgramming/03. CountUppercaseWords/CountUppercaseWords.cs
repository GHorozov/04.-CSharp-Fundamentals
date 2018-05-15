using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var list = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var word = input[i];
                if (char.IsUpper(word[0]))
                {
                    list.Add(word);
                }
            }

            Console.WriteLine(string.Join("\n", list));
            
        }
    }
}
