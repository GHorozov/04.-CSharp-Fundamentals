namespace _02._01._Knight_Game
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            var removeHorses = 0;
            while (true)
            {
                var maxHits = 0;
                var maxHitRow = 0;
                var maxHitCol = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var currentElement = matrix[row][col];
                        var currenElementHits = 0;
                        if (currentElement == 'K')
                        {
                            //left
                            if (IsInMatrix(matrix, row - 1, col - 2) && matrix[row - 1][col - 2] == 'K')
                            {
                                currenElementHits++;
                            }
                            if (IsInMatrix(matrix, row + 1, col - 2) && matrix[row + 1][col - 2] == 'K')
                            {
                                currenElementHits++;
                            }

                            //right
                            if (IsInMatrix(matrix, row - 1, col + 2) && matrix[row - 1][col + 2] == 'K')
                            {
                                currenElementHits++;
                            }
                            if (IsInMatrix(matrix, row + 1, col + 2) && matrix[row + 1][col + 2] == 'K')
                            {
                                currenElementHits++;
                            }

                            //up
                            if (IsInMatrix(matrix, row - 2, col - 1) && matrix[row - 2][col - 1] == 'K')
                            {
                                currenElementHits++;
                            }
                            if (IsInMatrix(matrix, row - 2, col + 1) && matrix[row - 2][col + 1] == 'K')
                            {
                                currenElementHits++;
                            }

                            //down
                            if (IsInMatrix(matrix, row + 2, col - 1) && matrix[row + 2][col - 1] == 'K')
                            {
                                currenElementHits++;
                            }
                            if (IsInMatrix(matrix, row + 2, col + 1) && matrix[row + 2][col + 1] == 'K')
                            {
                                currenElementHits++;
                            }
                        }

                        if (currenElementHits > maxHits)
                        {
                            maxHits = currenElementHits;
                            maxHitRow = row;
                            maxHitCol = col;
                        }
                    }
                }

                if (maxHits == 0)
                {
                    break;
                }
                else
                {
                    matrix[maxHitRow][maxHitCol] = '0';
                    removeHorses++;
                }
            }

            Console.WriteLine(removeHorses);
        }

        private static bool IsInMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
