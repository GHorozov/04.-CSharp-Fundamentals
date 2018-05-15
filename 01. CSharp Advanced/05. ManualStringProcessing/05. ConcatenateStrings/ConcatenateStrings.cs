using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatenateStrings
{
    class ConcatenateStrings
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var currentWord = Console.ReadLine();
                sb.Append(currentWord+ " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
