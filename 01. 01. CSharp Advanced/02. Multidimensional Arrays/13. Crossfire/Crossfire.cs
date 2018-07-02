namespace _13._Crossfire
{
    using System;
    using System.Linq;

    class Crossfire
    {
        static void Main(string[] args)
        {
            var demensions = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            var rowsNumber = demensions[0];
            var colsNumber = demensions[1];
            var matrix = new int[rowsNumber][];

            matrix = FillTheMatrix(matrix, rowsNumber, colsNumber);

            var command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                var commandParts = command
                .Split()
                .Select(int.Parse)
                .ToArray();

                var rowCenter = commandParts[0];
                var colCenter = commandParts[1];
                var radius = commandParts[2];

                matrix = DestroyTheCells(matrix, rowCenter, colCenter, radius);

                command = Console.ReadLine().Trim();
            }

            PrintMatrix(matrix);
        }


        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row].Where(c => c != -1)));
            }
        }

        private static int[][] DestroyTheCells(int[][] matrix, int rowCenter, int colCenter, int radius)
        {
            var upBlast = rowCenter - radius;
            var downBlast = rowCenter + radius;
            for (int row = upBlast; row <= downBlast; row++)
            {
                if (IsInMatrix(matrix, row, colCenter))
                {
                    matrix[row][colCenter] = -1;
                }
            }

            var leftBlast = colCenter - radius;
            var rightBlast = colCenter + radius;
            for (int col = leftBlast; col <= rightBlast; col++)
            {
                if (IsInMatrix(matrix, rowCenter, col))
                {
                    matrix[rowCenter][col] = -1;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] < 0)
                    {
                        matrix[row] = matrix[row].Where(x => x > 0).ToArray();
                    }
                }

                if (matrix[row].Count() < 1)
                {
                    matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                    row--;
                }
            }

            return matrix;
        }

        private static int[][] FillTheMatrix(int[][] matrix, int rowsNumber, int colsNumber)
        {
            var counter = 1;
            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[colsNumber];
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }

            return matrix;
        }

        private static bool IsInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
