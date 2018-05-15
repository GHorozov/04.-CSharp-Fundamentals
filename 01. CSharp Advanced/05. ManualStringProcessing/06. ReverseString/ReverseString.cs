using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var arr = input.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);
        }
    }
}
