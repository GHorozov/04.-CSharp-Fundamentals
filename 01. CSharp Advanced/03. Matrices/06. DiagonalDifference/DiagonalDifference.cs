using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();  
            }

            var sumDiagonalOne = 0;
            var colNum = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                colNum = row;
                sumDiagonalOne += matrix[row][colNum];
            }


            var sumDiagonalTwo = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                sumDiagonalTwo += matrix[row][matrix[row].Length - row - 1];
            }

            var result = Math.Abs(sumDiagonalOne - sumDiagonalTwo);
            Console.WriteLine(result);
        }
    }
}
