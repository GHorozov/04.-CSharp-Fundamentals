namespace _01.DangerousFloor
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var matrix = new char[8][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var inputLine = Console.ReadLine().Split(',');
                matrix[row] = new char[inputLine.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = char.Parse(inputLine[col]);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineArgs = input.Split('-');
                var figure = char.Parse(lineArgs[0].Substring(0, 1));
                var currentRow = int.Parse(lineArgs[0].Substring(1, 1));
                var currentCol = int.Parse(lineArgs[0].Substring(2, 1));
                var targetRow = int.Parse(lineArgs[1].Substring(0, 1));
                var targetCol = int.Parse(lineArgs[1].Substring(1, 1));

                if (matrix[currentRow][currentCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsInMatrix(matrix, targetRow, targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                switch (figure)
                {
                    case 'K':
                        ProccessKingMove(matrix, currentRow, currentCol, targetRow, targetCol, figure);
                        break;
                    case 'R':
                        ProccessRookMove(matrix, currentRow, currentCol, targetRow, targetCol, figure);
                        break;
                    case 'B':
                        ProccessBishopMove(matrix, currentRow, currentCol, targetRow, targetCol, figure);
                        break;
                    case 'Q':
                        ProccessQueenMove(matrix, currentRow, currentCol, targetRow, targetCol, figure);
                        break;
                    case 'P':
                        ProccessPawnMove(matrix, currentRow, currentCol, targetRow, targetCol, figure);
                        break;
                }
            }
        }

        private static void ProccessKingMove(char[][] matrix, int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            var isValid = Math.Abs(targetRow - currentRow) <= 1 &&
                          Math.Abs(targetCol - currentCol) <= 1;

            if (isValid)
            {
                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void ProccessRookMove(char[][] matrix, int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            var isValid = targetRow == currentRow ||
                          targetCol == currentCol;

            if (isValid)
            {
                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void ProccessBishopMove(char[][] matrix, int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            bool isValid = Math.Abs(currentRow - targetRow) == Math.Abs(currentCol - targetCol) ||
                           Math.Abs(currentRow + currentCol) == Math.Abs(targetRow + targetCol);

            if (isValid)
            {
                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void ProccessQueenMove(char[][] matrix, int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            var isValid = Math.Abs(currentRow - targetRow) == Math.Abs(currentCol - targetCol) ||
                         targetRow == currentRow ||
                         targetCol == currentCol;

            if (isValid)
            {
                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static void ProccessPawnMove(char[][] matrix, int currentRow, int currentCol, int targetRow, int targetCol, char figure)
        {
            var isValid = targetRow == currentRow - 1 &&
                         targetCol == currentCol;

            if (isValid)
            {
                matrix[currentRow][currentCol] = 'x';
                matrix[targetRow][targetCol] = figure;
            }
            else
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static bool IsInMatrix(char[][] matrix, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow <= matrix.Length - 1 && targetCol >= 0 && targetCol <= matrix.Length - 1;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
