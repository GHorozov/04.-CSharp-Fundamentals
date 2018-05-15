using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecondNature
{
    class SecondNature
    {
        static void Main(string[] args)
        {
            var flowers = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).Reverse());
            var buckets = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            var secondNature = new List<int>();
            while (flowers.Count> 0 && buckets.Count > 0)
            {
                var currentFlower = flowers.Pop();

                while(buckets.Count > 0 && currentFlower - buckets.Peek() > 0)
                {
                    currentFlower -= buckets.Pop(); //Watering the flowers.
                }

                var reminder = 0;
                if(buckets.Count > 0)
                {
                    if(currentFlower - buckets.Peek() < 0)
                    {
                        reminder = buckets.Pop() - currentFlower;
                    }
                    else
                    {
                        secondNature.Add(currentFlower);
                        buckets.Pop();
                    }

                    currentFlower = -1;
                    if(buckets.Count > 0)
                    {
                        buckets.Push(buckets.Pop() + reminder);
                    }
                    else if(reminder > 0)
                    {
                        buckets.Push(reminder);
                    }
                }

                if(currentFlower > 0)
                {
                    flowers.Push(currentFlower);
                }
            }

            if(flowers.Count > 0)
            {
                Console.WriteLine(string.Join(" ",flowers));
            }
            else
            {
                Console.WriteLine(string.Join(" ", buckets));
            }



            if (secondNature.Any())
            {
                Console.WriteLine(string.Join(" ", secondNature));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
