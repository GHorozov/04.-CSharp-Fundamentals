using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
                
        }
    }
}
