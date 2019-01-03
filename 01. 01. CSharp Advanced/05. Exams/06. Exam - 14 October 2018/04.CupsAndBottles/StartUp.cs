namespace _04.CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cups = new Queue<int>(inputCups);
            var inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottles = new Stack<int>(inputBottles);
            var wastedWater = 0;

            var isAllCupsFull = false;
            var isAllBottlesGone = false;
            while (true)
            {
                if (isAllBottlesGone) break;

                if(cups.Count == 0)
                {
                    isAllCupsFull = true;
                    break;
                }
                if (bottles.Count == 0)
                {
                    isAllBottlesGone = true;
                    break;
                }

                var currentCup = cups.Dequeue();
                var currentBottle = bottles.Pop();

                if(currentBottle >= currentCup)
                {
                    var leftOver = currentBottle - currentCup;
                    wastedWater += leftOver;
                }
                else
                {
                    while (currentBottle < currentCup)
                    {
                        if(bottles.Count > 0)
                        {
                            currentBottle += bottles.Pop();
                        }
                        else
                        {
                            isAllBottlesGone = true;
                            break;
                        }
                    }

                    var leftOver = currentBottle - currentCup;
                    wastedWater += leftOver;
                }
            }

            if (isAllBottlesGone)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups.ToArray())}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (isAllCupsFull)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.ToArray())}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
