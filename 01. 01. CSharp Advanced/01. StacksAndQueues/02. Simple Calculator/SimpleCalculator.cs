namespace _02._Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Reverse();
            var stack = new Stack<string>(input);
            while (stack.Count > 1)
            {
                var leftNumber = int.Parse(stack.Pop());
                var sign = stack.Pop();
                var rightNumber = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((leftNumber + rightNumber).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((leftNumber - rightNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
