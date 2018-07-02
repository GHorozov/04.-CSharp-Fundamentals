namespace _11._Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var result = new Queue<long>();
            queue.Enqueue(n);

            //First solutuion
            for (int i = 0; i < 50; i++)
            {
                var currentNumber = queue.Peek();
                queue.Enqueue(currentNumber + 1);
                queue.Enqueue((2 * currentNumber) + 1);
                queue.Enqueue(currentNumber + 2);

                result.Enqueue(queue.Dequeue());
            }

            while (result.Count > 0)
            {
                Console.Write(result.Dequeue() + " ");
            }


            //Second solution
            //var n = long.Parse(Console.ReadLine());
            //var queue = new Queue<long>();
            //var next = new Queue<long>();
            //var queueFormulas = new Queue<long>();
            //queueFormulas.Enqueue(1);
            //queueFormulas.Enqueue(2);
            //queueFormulas.Enqueue(3);
            //queue.Enqueue(n);


            //for (int i = 1; i <= 50; i++)
            //{
            //    var popedElement = queueFormulas.Dequeue();
            //    queueFormulas.Enqueue(popedElement);
            //    if(popedElement == 1)
            //    {
            //        var f = n + 1;
            //        queue.Enqueue(n + 1);
            //        next.Enqueue(f);
            //    }
            //    else if(popedElement == 2)
            //    {
            //        var f = (2 * n) + 1;
            //        queue.Enqueue((2 * n) + 1);
            //        next.Enqueue(f);
            //    }
            //    else if(popedElement == 3)
            //    {
            //        var f = n + 2;
            //        queue.Enqueue(n + 2);
            //        next.Enqueue(f);
            //    }

            //    if(i % 3 == 0)
            //    {
            //        n = next.Dequeue();
            //    }
            //}


            //for (int i = 0; i < 50; i++)
            //{
            //    Console.Write(queue.Dequeue() + " ");
            //}
        }
    }
}
