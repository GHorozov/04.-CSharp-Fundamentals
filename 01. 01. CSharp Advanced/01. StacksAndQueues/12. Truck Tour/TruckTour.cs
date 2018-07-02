namespace _12._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTour
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            for (int start = 0; start < n; start++)
            {
                var fuel = 0;
                var isSolution = true;
                for (int passedPumps = 0; passedPumps < n; passedPumps++)
                {
                    var pump = queue.Dequeue();
                    queue.Enqueue(pump);
                    var pumpFuel = pump[0];
                    var nextPumpDistance = pump[1];
                    fuel += (pumpFuel - nextPumpDistance);
                    if(fuel < 0)
                    {
                        start += passedPumps;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(start);
                    return;
                }
            }
        }
    }
}
