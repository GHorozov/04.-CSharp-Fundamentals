namespace _03._Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumElement
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var stackMax = new Stack<int>();
            stackMax.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var command = line[0];

                if (command == 1)
                {
                    var element = line[1];
                    stack.Push(element);
                    if (element >= stackMax.Peek())
                    {
                        stackMax.Push(element);
                    }
                }
                else if (command == 2)
                {
                    var popedElement = stack.Pop();
                    if (popedElement == stackMax.Peek())
                    {
                        stackMax.Pop();
                    }
                }
                else if (command == 3)
                {
                    Console.WriteLine(stackMax.Peek());
                }

            }
        }
    }
}
