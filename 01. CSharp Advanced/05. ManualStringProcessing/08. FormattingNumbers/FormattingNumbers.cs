using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\t','\n' }, StringSplitOptions.RemoveEmptyEntries);
            var a = short.Parse(input[0]);   
            var b = decimal.Parse(input[1]);
            var c = decimal.Parse(input[2]);
            var aToBinary = Convert.ToString(a, 2);

            Console.WriteLine(string.Format("|{0,-10:X}|{1}|{2,10:f2}|{3,-10:f3}|", a, aToBinary.PadLeft(10, '0').Substring(0,10), b, c));
        }
    }
}
