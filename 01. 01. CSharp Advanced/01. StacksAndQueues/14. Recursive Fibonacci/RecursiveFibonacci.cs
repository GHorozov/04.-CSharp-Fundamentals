namespace _14._Recursive_Fibonacci
{
    using System;

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
            if (n <= 2)
            {
                return 1;
            }
           
            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }

            return fibNumbers[n - 1] = GetFibonachi(n - 1) + GetFibonachi(n - 2);
        }
    }
}
