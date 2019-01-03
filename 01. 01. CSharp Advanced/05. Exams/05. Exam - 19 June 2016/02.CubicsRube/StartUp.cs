namespace _02.CubicsRube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var totalSum = 0L;
            var celsAffected = 0L;
            string input;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var line = input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var firstDem = int.Parse(line[0]);
                var secondDem = int.Parse(line[1]);
                var thirthDem = int.Parse(line[2]);
                var particles = int.Parse(line[3]);

                if(firstDem >= 0 && firstDem < n &&
                   secondDem >= 0 && secondDem < n &&
                   thirthDem >= 0 && thirthDem < n)
                {
                    if(particles != 0)
                    {
                        totalSum += particles;
                        celsAffected++;
                    }
                }
            }

            var allCells = n * n * n;
            var notChangesCells = allCells - celsAffected;

            Console.WriteLine(totalSum);
            Console.WriteLine(notChangesCells);
        }
    }
}
