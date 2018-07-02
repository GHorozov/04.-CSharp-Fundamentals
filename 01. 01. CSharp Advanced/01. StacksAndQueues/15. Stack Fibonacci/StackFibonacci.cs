namespace _15._Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            var a = 0L;
            var b = 1L;
            
            stack.Push(a);
            stack.Push(b);
            for (int i = 1; i < n; i++)
            {
                var popedB = stack.Pop();
                var peekA = stack.Peek();
                stack.Push(popedB);

                var temp = a;
                a = b;
                b = peekA + popedB;

                stack.Push(b);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
