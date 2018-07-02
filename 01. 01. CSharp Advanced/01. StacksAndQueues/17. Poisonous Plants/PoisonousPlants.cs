namespace _17._Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PoisonousPlants
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToList();

            var days = 0;
            var plantsToDie = new Stack<int>();

            while (true)
            {
                var isAllAlive = true;
                for (int i = 0; i < plants.Count - 1; i++)
                {          
                    var first = plants[i];
                    var second = plants[i + 1];
                    if (first < second)
                    {
                        var index = i + 1;
                        plantsToDie.Push(index);
                        isAllAlive = false;
                    }
                }

                if (isAllAlive)
                {
                    break;
                }
                else
                {
                    while(plantsToDie.Count > 0)
                    {
                        var indexToRemove = plantsToDie.Pop();
                        plants.RemoveAt(indexToRemove);
                    }
                }

                days++;
            }

            Console.WriteLine(days);
        }
    }
}
