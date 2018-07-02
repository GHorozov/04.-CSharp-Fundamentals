namespace _07._Squares_in_Matrix
{
    using System;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rowsNumber = input[0];
            var colsNumber = input[1];
            var matrix = new char[rowsNumber, colsNumber];

            ReadMatrix(matrix);

            var count = 0;
            for (int row = 0; row < rowsNumber - 1; row++)
            {
                for (int col = 0; col < colsNumber - 1; col++)
                {
                    if(matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);

        }

        private static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
