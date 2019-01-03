namespace _02.ParkingFeud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static int rows;
        static int cols;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = size[0];
            cols = size[1];
            var entrance = int.Parse(Console.ReadLine());

            var totalSteps = 0;
            while (true)
            {
                var inputLine = Console.ReadLine().Split();
                var samSpot = inputLine[entrance - 1];
                var currentSamSteps = GetSteps(entrance, samSpot);
                var isParked = true;

                for (int i = 0; i < inputLine.Length; i++)
                {
                    var isSameSpot = inputLine[i] == samSpot;
                    var isDifferentRow = (i + 1) != entrance; 

                    if(isSameSpot && isDifferentRow)
                    {
                        var enemySteps = GetSteps(i + 1, inputLine[i]);

                        if(enemySteps < currentSamSteps)
                        {
                            totalSteps += currentSamSteps * 2;
                            isParked = false;
                            break;
                        }
                    }
                }

                if (isParked)
                {
                    totalSteps += currentSamSteps;
                    Console.WriteLine($"Parked successfully at {samSpot}.");
                    Console.WriteLine($"Total Distance Passed: {totalSteps}");
                    return;
                }
            }
        }

        private static int GetSteps(int entrance, string samSpot)
        {
            var targetRow = int.Parse(samSpot.Substring(1));
            var targetCol = samSpot[0] - 'A' + 1;

            var currentSteps = 0;
            var isRight = true;
            while (targetRow != entrance && targetRow - 1 != entrance)
            {
                currentSteps += cols + 3;

                if(entrance > targetRow)
                {
                    entrance--;
                }

                if(entrance < targetRow)
                {
                    entrance++; 
                }

                isRight = !isRight;
            }

            if (isRight)
            {
                currentSteps += targetCol;
            }
            else
            {
                currentSteps += cols - targetCol + 1; 
            }

            return currentSteps;
        }
    }
}
