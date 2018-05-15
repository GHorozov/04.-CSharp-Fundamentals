using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];

                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }

                symbols[symbol] += 1;
            }

            foreach (var pair in symbols)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }

        }
    }
}
