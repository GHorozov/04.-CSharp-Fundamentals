namespace _1._Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            var rowsNumber = input[0];
            var colsNumber = input[1];

            var matrix = new int[rowsNumber, colsNumber];
            var sum = 0;
            for (int row = 0; row < rowsNumber; row++)
            {
                var currentRow = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int col = 0; col < colsNumber; col++)
                {
                    matrix[row, col] = currentRow[col];
                    sum += currentRow[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
