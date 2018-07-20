namespace _02._Knight_Game
{
    using System;
    using System.Collections.Generic;

    class KnightGame
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            matrix = FillTheMatrix(matrix);

            var result = 0;

            while (true)
            {
                var maxHorseKills = 0;
                var maxHorseRow = 0;
                var maxHorseCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            var currentHorseKills = 0;

                            //left 
                            if (IsInMatrix(row + 2, col - 1, n) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 2, col - 1, n) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row + 1, col - 2, n) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 1, col - 2, n) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentHorseKills++;
                            }

                            //right 
                            if (IsInMatrix(row + 2, col + 1, n) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 2, col + 1, n) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row + 1, col + 2, n) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 1, col + 2, n) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentHorseKills++;
                            }

                            //up 
                            if (IsInMatrix(row - 1, col + 2, n) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 1, col - 2, n) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 2, col + 1, n) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row - 2, col - 1, n) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentHorseKills++;
                            }

                            //down 
                            if (IsInMatrix(row + 1, col - 2, n) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row + 1, col + 2, n) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row + 2, col - 1, n) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentHorseKills++;
                            }
                            if (IsInMatrix(row + 2, col + 1, n) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentHorseKills++;
                            }

                            if (currentHorseKills > maxHorseKills)
                            {
                                maxHorseKills = currentHorseKills;
                                maxHorseRow = row;
                                maxHorseCol = col;
                            }
                        }
                    }
                }


                if(maxHorseKills > 0)
                {
                    matrix[maxHorseRow, maxHorseCol] = '0';
                    result++;
                }
                else
                {
                    Console.WriteLine(result);
                    Environment.Exit(0);
                }
            }

        }

        private static bool IsInMatrix(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static char[,] FillTheMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
