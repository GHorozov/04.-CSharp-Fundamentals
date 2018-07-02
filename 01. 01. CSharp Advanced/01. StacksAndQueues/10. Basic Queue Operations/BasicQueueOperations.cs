namespace _10._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbersToEnqueue = input[0];
            var numberToDequeue = input[1];
            var numberToCheckInQueue = input[2];

            var inputSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < numbersToEnqueue; i++)
            {
                queue.Enqueue(inputSequence[i]);
            }

            for (int i = 0; i < numberToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToCheckInQueue))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0 && !queue.Contains(numberToCheckInQueue))
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
