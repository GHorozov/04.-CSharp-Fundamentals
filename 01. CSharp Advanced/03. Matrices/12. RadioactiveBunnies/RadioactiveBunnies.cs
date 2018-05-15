using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numberOfRows = input[0];
            var numberOfCols = input[1];

            var matrix = new char[numberOfRows][];

            var playerRow = 0;
            var playerCol = 0;

            for (int row = 0; row < numberOfRows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                if (matrix[row].Contains('P'))
                {
                    playerRow = row;

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            playerCol = col; break;
                        }
                    }
                }
            }


            var command = Console.ReadLine().ToCharArray();

            for (int move = 0; move < command.Length; move++)
            {
                var direction = command[move];

                if (direction == 'L')
                {
                    // if next move is IN matrix.
                    if (playerCol - 1 < matrix.Length && playerCol - 1 >= 0)
                    {
                        //if I hit Bunny.
                        if (matrix[playerRow][playerCol - 1] == 'B')
                        {
                            //save last position of row and col to print.
                            var lastPositionRow = playerRow;
                            var lastPositionCol = playerCol - 1;

                            ReplicateBunnies(matrix);

                            PrintMatrix(matrix);

                            Console.WriteLine($"dead: {lastPositionRow} {lastPositionCol}");
                            return;
                        }
                        else
                        {
                            // just move Player.
                            matrix[playerRow][playerCol - 1] = 'P';
                            matrix[playerRow][playerCol] = '.';

                            var hitP = ReplicateBunnies(matrix);
                            if (hitP == true)
                            {
                                PrintMatrix(matrix);
                                Console.WriteLine($"dead: {playerRow} {playerCol - 1}"); return;
                            }
                            //save last known position for col. 
                            playerCol = playerCol - 1;
                        }
                    }
                    else
                    {
                        var lastRowPos = playerRow;
                        var lastColPos = playerCol;

                        matrix[playerRow][playerCol] = '.';

                        ReplicateBunnies(matrix);

                        PrintMatrix(matrix);

                        Console.WriteLine($"won: {lastRowPos} {lastColPos}");
                        return;
                    }
                }
                else if (direction == 'R')
                {
                    // if next move is IN matrix.
                    if (playerCol + 1 < matrix.Length && playerCol + 1 >= 0)
                    {
                        //if I hit Bunny.
                        if (matrix[playerRow][playerCol + 1] == 'B')
                        {
                            //save last position of row and col to print.
                            var lastPositionRow = playerRow;
                            var lastPositionCol = playerCol + 1;

                            ReplicateBunnies(matrix);

                            PrintMatrix(matrix);

                            Console.WriteLine($"dead: {lastPositionRow} {lastPositionCol}");
                            return;
                        }
                        else
                        {
                            // just move Player.
                            matrix[playerRow][playerCol + 1] = 'P';
                            matrix[playerRow][playerCol] = '.';

                            var hitP = ReplicateBunnies(matrix);
                            if (hitP == true)
                            {
                                PrintMatrix(matrix);
                                Console.WriteLine($"dead: {playerRow} {playerCol + 1}"); return;
                            }
                            //save last known position for col. 
                            playerCol = playerCol + 1;
                        }
                    }
                    else
                    {
                        var lastRowPos = playerRow;
                        var lastColPos = playerCol;

                        matrix[playerRow][playerCol] = '.';

                        ReplicateBunnies(matrix);

                        PrintMatrix(matrix);

                        Console.WriteLine($"won: {lastRowPos} {lastColPos}");
                        return;
                    }
                }
                else if (direction == 'U')
                {
                    // if next move is IN matrix.
                    if (playerRow - 1 < numberOfCols && playerRow - 1 >= 0)
                    {
                        //if I hit Bunny.
                        if (matrix[playerRow - 1][playerCol] == 'B')
                        {
                            //save last position of row and col to print.
                            var lastPositionRow = playerRow - 1;
                            var lastPositionCol = playerCol;

                            ReplicateBunnies(matrix);

                            PrintMatrix(matrix);

                            Console.WriteLine($"dead: {lastPositionRow} {lastPositionCol}");
                            return;
                        }
                        else
                        {
                            // just move Player.
                            matrix[playerRow - 1][playerCol] = 'P';
                            matrix[playerRow][playerCol] = '.';

                            var hitP = ReplicateBunnies(matrix);
                            if (hitP == true)
                            {
                                PrintMatrix(matrix);
                                Console.WriteLine($"dead: {playerRow - 1} {playerCol}"); return;
                            }
                            //save last known position for col. 
                            playerRow = playerRow - 1;
                        }
                    }
                    else
                    {
                        var lastRowPos = playerRow;
                        var lastColPos = playerCol;

                        matrix[playerRow][playerCol] = '.';

                        ReplicateBunnies(matrix);

                        PrintMatrix(matrix);

                        Console.WriteLine($"won: {lastRowPos} {lastColPos}");
                        return;
                    }
                }
                else if (direction == 'D')
                {
                    // if next move is IN matrix.
                    if (playerRow + 1 < numberOfCols && playerRow + 1 >= 0)
                    {
                        //if I hit Bunny.
                        if (matrix[playerRow + 1][playerCol] == 'B')
                        {
                            //save last position of row and col to print.
                            var lastPositionRow = playerRow + 1;
                            var lastPositionCol = playerCol;

                            ReplicateBunnies(matrix);

                            PrintMatrix(matrix);

                            Console.WriteLine($"dead: {lastPositionRow} {lastPositionCol}");
                            return;
                        }
                        else
                        {
                            // just move Player.
                            matrix[playerRow + 1][playerCol] = 'P';
                            matrix[playerRow][playerCol] = '.';

                            var hitP = ReplicateBunnies(matrix);
                            if (hitP == true)
                            {
                                PrintMatrix(matrix);
                                Console.WriteLine($"dead: {playerRow + 1} {playerCol}"); return;
                            }
                            //save last known position for col. 
                            playerRow = playerRow + 1;
                        }
                    }
                    else
                    {
                        var lastRowPos = playerRow;
                        var lastColPos = playerCol;

                        matrix[playerRow][playerCol] = '.';

                        ReplicateBunnies(matrix);

                        PrintMatrix(matrix);

                        Console.WriteLine($"won: {lastRowPos} {lastColPos}");
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static bool ReplicateBunnies(char[][] matrix)
        {
            var hitBunny = false;
            var reserveRows = new Queue<int>();
            var reserveCols = new Queue<int>();

            var bunnyCounter = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentPosition = matrix[row][col];

                    if (currentPosition == 'B')
                    {
                        reserveRows.Enqueue(row);
                        reserveCols.Enqueue(col);

                        bunnyCounter++;
                    }
                }
            }

            for (int i = 0; i < bunnyCounter; i++)
            {
                var row = reserveRows.Dequeue();
                var col = reserveCols.Dequeue();

                try
                {
                    if (matrix[row - 1][col] == 'P')
                    {
                        hitBunny = true;
                    }
                    matrix[row - 1][col] = 'B';

                }
                catch (Exception)
                {
                }

                try
                {
                    if (matrix[row + 1][col] == 'P')
                    {
                        hitBunny = true;
                    }

                    matrix[row + 1][col] = 'B';

                }
                catch (Exception)
                {
                }

                try
                {
                    if (matrix[row][col - 1] == 'P')
                    {
                        hitBunny = true;
                    }
                    matrix[row][col - 1] = 'B';

                }
                catch (Exception)
                {
                }

                try
                {
                    if (matrix[row][col + 1] == 'P')
                    {
                        hitBunny = true;
                    }
                    matrix[row][col + 1] = 'B';

                }
                catch (Exception)
                {
                }
            }

            return hitBunny;
        }
    }
}
