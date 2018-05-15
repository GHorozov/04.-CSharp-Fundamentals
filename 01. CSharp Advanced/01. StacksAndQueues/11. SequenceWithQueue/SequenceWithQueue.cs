using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var resultQueue = new Queue<long>();
            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                var currentTop = queue.Peek();
                queue.Enqueue(currentTop + 1);
                queue.Enqueue(2 * currentTop + 1);
                queue.Enqueue(currentTop + 2);

                resultQueue.Enqueue(queue.Dequeue());
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(resultQueue.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}
