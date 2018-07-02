namespace _01._StacksAndQueues
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
