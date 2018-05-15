using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NumberWars
{
    class NumberWarsTask
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            //filling matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var currentHorseKills = 0;
            var maxHorseKills = int.MinValue;
            var maxRow = -1;
            var maxCol = -1;
            var countKillHorses = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var currentCell = matrix[row, col];
                        if (currentCell == 'K')
                        {
                            //up left
                            if (IsInMatrix(matrix, row - 2, col - 1))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            if (IsInMatrix(matrix, row - 1, col - 2))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            //up right
                            if (IsInMatrix(matrix, row - 2, col + 1))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            if (IsInMatrix(matrix, row - 1, col + 2))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            //down left
                            if (IsInMatrix(matrix, row + 1, col - 2))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            if (IsInMatrix(matrix, row + 2, col - 1))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            //down right
                            if (IsInMatrix(matrix, row + 1, col + 2))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            if (IsInMatrix(matrix, row + 2, col + 1))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    currentHorseKills++;
                                }
                            }

                            if (currentHorseKills > maxHorseKills)
                            {
                                maxHorseKills = currentHorseKills;
                                maxRow = row;
                                maxCol = col;
                            }

                            currentHorseKills = 0;
                        }
                    }
                }

                if (maxHorseKills != 0)
                {
                    matrix[maxRow, maxCol] = 'O';
                    countKillHorses++;
                    maxHorseKills = int.MinValue;
                }
                else
                {
                    Console.WriteLine(countKillHorses);
                    return;
                }

            }

        }

        private static bool IsInMatrix(char[,] matrix, int row, int col)
        {
            bool result = (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));

            return result;
        }
    }
}
