namespace _13._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if(input.Length % 2 != 0)
            {
                NotBalanced();
            }

            var opened = new[] { '(', '[', '{' };
            var closed = new[] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opened.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closed.Contains(element))
                {
                    var popedElement = stack.Pop();
                    var indexOpenedP = Array.IndexOf(opened, popedElement);
                    var indexClosedP = Array.IndexOf(closed, element);
                    
                    if(indexOpenedP != indexClosedP)
                    {
                        NotBalanced();
                        
                    }

                }
            }

            if(stack.Any() )
            {
                NotBalanced();
            }
            else
            {
                Console.WriteLine("YES");
            }
        }

        private static void NotBalanced()
        {
            Console.WriteLine("NO");
            Environment.Exit(0);
        }
    }
}
