using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[input[0]][];

           
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxSum = int.MinValue;
            var cellRow = 0;
            var cellCol = 0;
            for (int row = 0; row < matrix.Length-2; row++)
            {
                var currentSum = 0;
                for (int col = 0; col < matrix[row].Length-2; col++)
                {
                    currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                        + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                        + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        cellRow = row;
                        cellCol = col;
                    }
                }
            }


            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[cellRow][cellCol]} {matrix[cellRow][cellCol+1]} {matrix[cellRow][cellCol+2]} \n{matrix[cellRow+1][cellCol]} {matrix[cellRow+1][cellCol+1]} {matrix[cellRow+1][cellCol+2]} \n{matrix[cellRow+2][cellCol]} {matrix[cellRow+2][cellCol+1]} {matrix[cellRow+2][cellCol+2]}");
        }
    }
}
