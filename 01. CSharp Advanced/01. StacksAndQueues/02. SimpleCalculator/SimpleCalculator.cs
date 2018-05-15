using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var trimSpaceArray = input.Split(' ');
            var stack = new Stack<string>(trimSpaceArray.Reverse());

            while(stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var sign = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if(sign == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
