namespace _3._Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var stack = new Stack<int>();
            while (number > 0)
            {
                stack.Push(number % 2);
                number /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
