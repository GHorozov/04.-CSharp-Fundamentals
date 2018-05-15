using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var elemToPush = input[0];
            var elemToPop = input[1];
            var elemToCheck = input[2];

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); 
            var stack = new Stack<int>();

            for (int i = 0; i < elemToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elemToPop; i++)
            {
                stack.Pop();
            }

            var isPresent = stack.Contains(elemToCheck);

            if (isPresent)
            {
                Console.WriteLine("true");
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
