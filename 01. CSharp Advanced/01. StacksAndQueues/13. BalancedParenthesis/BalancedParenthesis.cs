using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var sequance = Console.ReadLine();
            var stack = new Stack<char>();

            var openParantesis = new char[] { '(', '{', '[' };

            for (int i = 0; i < sequance.Length; i++)
            {
                if (openParantesis.Contains(sequance[i]))
                {
                    stack.Push(sequance[i]);
                }
                else
                {
                    if (stack.Count() == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (sequance[i])
                    {
                        case ')':
                            if (stack.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }

                            break;
                        case '}':
                            if (stack.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }

                            break;
                        case ']':
                            if (stack.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
