using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        private static long[] fibNumbers;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            fibNumbers = new long[n];
            var result = GetFibonachi(n);

            Console.WriteLine(result);
        }

        private static long GetFibonachi(int n)
        {
            if(n <= 2)
            {
                return 1;
            }
            //if wanted number n is != 0. If it is return number from array fibNumbers on this cell.
            if(fibNumbers[n -1] != 0)
            {
                return fibNumbers[n - 1];
            }

            return fibNumbers[n -1] =  GetFibonachi(n - 1) + GetFibonachi(n - 2);
        }
    }
}
