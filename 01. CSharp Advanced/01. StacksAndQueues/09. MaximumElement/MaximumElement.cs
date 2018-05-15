using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            var maxNumbers = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine().Split(' ').ToArray();
                var command = int.Parse(currentLine[0]);

                if(command == 1)
                {
                    var numberToPush = int.Parse(currentLine[1]);
                    stack.Push(numberToPush);

                    if(maxValue < numberToPush)
                    {
                        maxValue = numberToPush;
                        maxNumbers.Push(maxValue);
                    }
                }
                else if(command == 2)
                {
                    if(stack.Pop() == maxValue)
                    {
                        maxNumbers.Pop();

                        if(maxNumbers.Count != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if(command == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
