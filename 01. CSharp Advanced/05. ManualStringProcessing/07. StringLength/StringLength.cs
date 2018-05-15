using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if(input.Length < 20)
            {
                input = input.PadRight(20, '*');
            }
            else
            {
                var twentySymbols = "";
                for (int i = 0; i < 20; i++)
                {
                    twentySymbols += input[i];
                }
                input = twentySymbols;
            }

            Console.WriteLine(input);
        }
    }
}
