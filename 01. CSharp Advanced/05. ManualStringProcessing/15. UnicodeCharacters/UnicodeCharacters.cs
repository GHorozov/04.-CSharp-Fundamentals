using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            foreach (var symbol in input)
            {
                sb.AppendFormat(@"\u{0:x4}", (uint)symbol);
            }

            Console.WriteLine(sb);
        }
    }
}
