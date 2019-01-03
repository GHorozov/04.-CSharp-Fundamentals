namespace _02.Sneaking
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfRows = int.Parse(Console.ReadLine());
            var matrix = new char[numberOfRows][];
            var samPosition = new int[2];
            for (int row = 0; row < matrix.Length; row++)
            {
                var inputChars = Console.ReadLine().ToCharArray();
                matrix[row] = new char[inputChars.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = (char)inputChars[col];

                    if (matrix[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            var directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                UpdateEnemies(matrix);
                CheckIfEmeniesKillSam(matrix);
                MoveSam(matrix, direction, samPosition);
                CheckIfSamKillNikoladze(matrix);
            }
        }

        private static void UpdateEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentCell = matrix[row][col];

                    if (currentCell == 'd')
                    {
                        if (col == 0)
                        {
                            matrix[row][col] = 'b';
                        }
                        else if (col > 0)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                    }
                    else if (currentCell == 'b')
                    {
                        if (col == matrix[row].Length - 1)
                        {
                            matrix[row][col] = 'd';
                        }
                        else if (col < matrix[row].Length - 1)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;//
                        }
                    }
                }
            }
        }

        private static void CheckIfEmeniesKillSam(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if(matrix[row].Contains('b') && matrix[row].Contains('S'))
                {
                    var indexOfSamPosition = Array.IndexOf(matrix[row], 'S');
                    var indexOfEnemyPosition = Array.IndexOf(matrix[row], 'b');
                    if(indexOfEnemyPosition < indexOfSamPosition)
                    {
                        matrix[row][indexOfSamPosition] = 'X';
                        Console.WriteLine($"Sam died at {row}, {indexOfSamPosition}");
                        PrintMatrix(matrix);
                    }
                }
                else if(matrix[row].Contains('d') && matrix[row].Contains('S'))
                {
                    var indexOfSamPosition = Array.IndexOf(matrix[row], 'S');
                    var indexOfEnemyPosition = Array.IndexOf(matrix[row], 'd');
                    if (indexOfEnemyPosition > indexOfSamPosition)
                    {
                        matrix[row][indexOfSamPosition] = 'X';
                        Console.WriteLine($"Sam died at {row}, {indexOfSamPosition}");
                        PrintMatrix(matrix);
                    }
                }
            }
        }

        private static void MoveSam(char[][] matrix, char direction, int[] samPosition)
        {
            switch (direction)
            {
                case 'U':
                    matrix[samPosition[0]][samPosition[1]] = '.';
                    matrix[--samPosition[0]][samPosition[1]] = 'S';

                    break;
                case 'L':
                    matrix[samPosition[0]][samPosition[1]] = '.';
                    matrix[samPosition[0]][--samPosition[1]] = 'S';
                    break;
                case 'R':
                    matrix[samPosition[0]][samPosition[1]] = '.';
                    matrix[samPosition[0]][++samPosition[1]] = 'S';
                    break;
                case 'D':
                    matrix[samPosition[0]][samPosition[1]] = '.';
                    matrix[++samPosition[0]][samPosition[1]] = 'S';
                    break;
                case 'W':
                    break;
            }
        }

        private static void CheckIfSamKillNikoladze(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if(matrix[row].Contains('S') && matrix[row].Contains('N'))
                {
                    var indexOfNikoladze = Array.IndexOf(matrix[row], 'N');
                    matrix[row][indexOfNikoladze] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(matrix);
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }
    }
}
