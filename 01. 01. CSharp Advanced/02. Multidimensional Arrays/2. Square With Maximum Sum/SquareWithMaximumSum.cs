namespace _2._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowsNumber = input[0];
            var colsNumber = input[1];
            var matrix = new int[rowsNumber, colsNumber];
            for (int row = 0; row < rowsNumber; row++)
            {
                var currentRow = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < colsNumber; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var maxSum = 0;
            var smallMatrix = "";
            for (int row = 0; row < matrix.GetLength(0) -1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if(currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        smallMatrix = $"{matrix[row, col]} {matrix[row, col+1]}\n{matrix[row + 1, col]} {matrix[row + 1, col + 1]}";
                    }
                }
            }

            Console.WriteLine(smallMatrix);
            Console.WriteLine(maxSum);
        }
    }
}
