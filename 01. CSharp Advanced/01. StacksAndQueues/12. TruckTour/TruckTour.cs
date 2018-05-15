using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<long>();

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var amountPetrol = inputLine[0];
                var distance = inputLine[1];

                queue.Enqueue(amountPetrol - distance);
            }

            var index = 0;
            var petrol = -1L;

            for (int i = 0; i < n; i++)
            {
                if (queue.Peek() >= 0 && petrol < 0)
                {
                    index = i;
                    petrol = 0;
                }

                petrol += queue.Dequeue();
            }

            Console.WriteLine(index);
        }
    }
}
