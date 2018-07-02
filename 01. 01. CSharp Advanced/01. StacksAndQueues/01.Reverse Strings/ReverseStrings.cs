namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    class ReverseStrings
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var stack = new Stack<char>(text.ToCharArray());
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + "");
            }

            Console.WriteLine();
        }
    }
}
