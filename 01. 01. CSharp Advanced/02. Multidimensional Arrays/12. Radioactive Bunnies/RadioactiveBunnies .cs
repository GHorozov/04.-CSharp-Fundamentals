namespace _12._Radioactive_Bunnies
{
    using System;
    using System.Linq;

    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rowsNumber = input[0];
            var colsNumber = input[1];
            var matrix = new char[rowsNumber, colsNumber];

            var playerPosition = FillMatrix(matrix);

            StartAction(matrix, playerPosition, rowsNumber, colsNumber);
        }

        private static void StartAction(char[,] matrix, int[] playerPosition, int rowsNumber, int colsNumber)
        {
            var commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];

                switch (currentCommand)
                {
                    case 'U':
                        playerPosition[0] = playerPosition[0] - 1;
                        CheckResult(matrix, playerPosition[0], playerPosition[1], currentCommand);
                        break;
                    case 'D':
                        playerPosition[0] = playerPosition[0] + 1;
                        CheckResult(matrix, playerPosition[0], playerPosition[1], currentCommand);
                        break;
                    case 'L':
                        playerPosition[1] = playerPosition[1] - 1;
                        CheckResult(matrix, playerPosition[0], playerPosition[1], currentCommand);
                        break;
                    case 'R':
                        playerPosition[1] = playerPosition[1] + 1;
                        CheckResult(matrix, playerPosition[0], playerPosition[1], currentCommand);
                        break;
                }

            }
        }

        private static void CheckResult(char[,] matrix, int positionRow, int positionCol, char currentCommand)
        {
            if (!IsInMatrix(matrix, positionRow, positionCol))
            {
                BunniesGrow(matrix);
                PrintMatrix(matrix);
                if (currentCommand == 'U')
                {
                    Console.WriteLine($"won: {positionRow + 1} {positionCol}");
                }
                else if (currentCommand == 'D')
                {
                    Console.WriteLine($"won: {positionRow - 1} {positionCol}");
                }
                else if (currentCommand == 'L')
                {
                    Console.WriteLine($"won: {positionRow} {positionCol + 1}");
                }
                else if (currentCommand == 'R')
                {
                    Console.WriteLine($"won: {positionRow} {positionCol - 1}");
                }

                Environment.Exit(0);
            }

            BunniesGrow(matrix);

            if (matrix[positionRow, positionCol] == 'B')
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {positionRow} {positionCol}");
                Environment.Exit(0);
            }

            

        }

        private static void BunniesGrow(char[,] matrix)
        {
            var indexesMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        indexesMatrix[row, col] = 'B';
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (indexesMatrix[row, col] == 'B')
                    {
                        if (IsInMatrix(matrix, row - 1, col))
                        {
                            matrix[row - 1, col] = 'B';
                        }
                        if (IsInMatrix(matrix, row + 1, col))
                        {
                            matrix[row + 1, col] = 'B';
                        }
                        if (IsInMatrix(matrix, row, col - 1))
                        {
                            matrix[row, col - 1] = 'B';
                        }
                        if (IsInMatrix(matrix, row, col + 1))
                        {
                            matrix[row, col + 1] = 'B';
                        }
                    }
                }
            }
        }

        private static bool IsInMatrix(char[,] matrix, int positionRow, int positionCol)
        {
            if (positionRow > matrix.GetLength(0) - 1 || positionRow < 0 || positionCol > matrix.GetLength(1) - 1 || positionCol < 0)
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] FillMatrix(char[,] matrix)
        {
            var playerPosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    var current = matrix[row, col];
                    if (current == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                        matrix[row, col] = '.';
                    }
                }
            }

            return playerPosition;
        }
    }
}
