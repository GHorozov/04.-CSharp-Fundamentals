using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.JediGalaxy
{
    class JediGalaxyTask
    {
        static void Main(string[] args)
        {
            var matrixRowsCols = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrixRows = matrixRowsCols[0];
            var matrixCols = matrixRowsCols[1];

            int[,] matrix = new int[matrixRows, matrixCols];
            var count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = count++;
                }
            }

            var resultSum = 0L;

            string input;
            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivoPosition = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var ivoRow = ivoPosition[0];
                var ivoCol = ivoPosition[1];

                var evilPosition = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var evilRow = evilPosition[0];
                var evilCol = evilPosition[1];

                //First evel pass and make all cell zero.
                if (evilRow >= matrixRows)
                {
                    int shift = evilRow - matrixRows + 1;
                    evilRow -= shift;
                    evilCol -= shift;
                }

                if(evilCol >= matrixCols)
                {
                    int shift = evilCol - matrixCols + 1;
                    evilRow -= shift;
                    evilCol -= shift;
                }

                while(evilRow >= 0 && evilCol >= 0)
                {
                    matrix[evilRow, evilCol] = 0;
                    evilRow--;
                    evilCol--;
                }

                //Then sum all ivo's cells
                if (ivoRow >= matrixRows)
                {
                    var shift = ivoRow - matrixRows + 1;
                    ivoRow -= shift;
                    ivoCol += shift;
                }

                if(ivoCol < 0)
                {
                    int shift = Math.Abs(ivoCol);
                    ivoRow -= shift;
                    ivoCol += shift;
                }

                while (ivoRow >= 0 && ivoCol < matrixCols)
                {
                    resultSum += matrix[ivoRow, ivoCol];
                    ivoRow--;
                    ivoCol++;
                }
            }

            Console.WriteLine(resultSum);
        }
    }
}
