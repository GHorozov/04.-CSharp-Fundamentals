namespace _5._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    class HotPotato
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(kids);
            while (queue.Count > 1)
            {
                var count = 0;
                while (count < n)
                {
                    count++;
                    if (count != n)
                    {
                        var firstKid = queue.Dequeue();
                        queue.Enqueue(firstKid);
                    }
                    else
                    {
                        Console.WriteLine($"Removed {queue.Peek()}");
                        queue.Dequeue();
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
