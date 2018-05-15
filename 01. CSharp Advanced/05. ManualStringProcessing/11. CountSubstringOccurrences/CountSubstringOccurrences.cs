using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();
            var lastIndex = -1;
            var count = 0;

            while (true)
            {
                var found = text.IndexOf(pattern, lastIndex + 1);
                lastIndex = found;
                if (found != -1)
                {
                    count++;
                }
                if (found == -1) break;
            }

            Console.WriteLine(count);
        }
    }
}
