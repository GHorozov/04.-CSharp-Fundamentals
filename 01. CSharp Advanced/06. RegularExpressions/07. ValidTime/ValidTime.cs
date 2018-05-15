using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidTime
{
    class ValidTime
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            while (text != "END")
            {
                Regex regex = new Regex("^(0[0-9]|1[012]):[0-5][0-9]:[0-5][0-9] [AP]M$");
                Match match = regex.Match(text);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
                text = Console.ReadLine();
            }
        }
    }
}
