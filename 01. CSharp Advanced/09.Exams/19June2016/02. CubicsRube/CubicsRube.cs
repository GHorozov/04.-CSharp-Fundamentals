using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicsRube
{
    class CubicsRube
    {
        static void Main(string[] args)
        {
            int dimensionSize = int.Parse(Console.ReadLine());

            var sumParticles = 0L;
            var changedCells = 0L;

            string input;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var line = input.Split(' ').Select(long.Parse).ToArray();
                var dem1 = line[0];
                var dem2 = line[1];
                var dem3 = line[2];
                var particle = line[3];

               
                if(dem1 >=0 && dem1 < dimensionSize &&
                   dem2 >= 0 && dem2 < dimensionSize &&
                   dem3 >= 0 && dem3 < dimensionSize  )
                {
                    if (particle != 0) //When cell is not 0. If it is 0 the cell is not changed and i don have to increment changedCell.
                    {
                        sumParticles += particle;
                        changedCells++;
                    }
                }

            }

            Console.WriteLine(sumParticles);
            Console.WriteLine(Math.Pow(dimensionSize, 3) - changedCells);
        }
    }
}
