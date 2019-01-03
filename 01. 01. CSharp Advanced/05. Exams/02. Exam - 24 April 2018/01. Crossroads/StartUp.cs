namespace _01._Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var isChashHappend = false;
            var passedCars = 0;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }

                var tempGreen = greenLightDuration;
                string currentCar = null;
                while (cars.Any() && tempGreen > 0)
                {
                    currentCar = cars.Dequeue();
                    tempGreen -= currentCar.Length;
                    passedCars++;
                }

                var freeWindowLeft = tempGreen + freeWindowDuration;
                if (freeWindowLeft < 0)//crash happend!
                {
                    var indexOfHitSpot = currentCar.Length - Math.Abs(freeWindowLeft);
                    char hitSymbol = currentCar[indexOfHitSpot];
                    isChashHappend = true;
                    CrashHappend(currentCar, hitSymbol);
                }
            }

            if (!isChashHappend)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }

        private static void CrashHappend(string currentCar, char hitSymbol)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{currentCar} was hit at {hitSymbol}.");
            Environment.Exit(0);
        }
    }
}
