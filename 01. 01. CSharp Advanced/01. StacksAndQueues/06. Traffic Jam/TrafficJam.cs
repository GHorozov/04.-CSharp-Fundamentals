namespace _6._Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    class TrafficJam
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var counter = 0;
            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count == 0) break;
                        counter++;
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
