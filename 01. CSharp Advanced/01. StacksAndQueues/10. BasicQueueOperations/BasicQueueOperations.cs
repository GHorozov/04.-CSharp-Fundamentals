using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var elementToRemove = input[1];
            var elemToCheck = input[2];
            var queue = new Queue<int>();

            var secondInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(secondInput[i]);
            }

            for (int i = 0; i < elementToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elemToCheck))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
