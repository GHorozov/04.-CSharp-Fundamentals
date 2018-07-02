namespace _02._Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num)).ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num)).ToArray();

            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
