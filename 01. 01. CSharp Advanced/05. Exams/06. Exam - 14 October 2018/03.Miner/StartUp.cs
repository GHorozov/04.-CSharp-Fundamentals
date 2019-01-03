namespace _03.Miner
{
    using System;
    using System.Linq;

    class StartUp
    {
        private static int minerRow = 0;
        private static int minerCol = 0;
        private static int leftCoal = 0;
        private static string[] commands = null;
        private static char[][] matrix = null;
        private static int totalColsCollected = 0;
        private static bool isNotCollectAllCoals = true;
        private static bool isNotStepOnE = true;
        private static bool isNotCommandsOver = true;

        static void Main(string[] args)
        {
            var fieldSize = int.Parse(Console.ReadLine());
            commands = Console.ReadLine().Split().ToArray();
            matrix = new char[fieldSize][];

            Fillmatrix();

            while (true)
            {
                if (isNotCollectAllCoals == false) break;
                if (isNotStepOnE == false) break;
                if (isNotCommandsOver == false) break;

                MoveMiner();
            }

            if (!isNotCollectAllCoals)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else if (!isNotStepOnE)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (!isNotCommandsOver)
            {
                Console.WriteLine($"{leftCoal} coals left. ({minerRow}, {minerCol})");
            }
        }

        //private static void PrintMatrix()
        //{
        //    for (int row = 0; row < matrix.Length; row++)
        //    {
        //        for (int col = 0; col < matrix[row].Length; col++)
        //        {
        //            Console.Write(matrix[row][col]);
        //        }

        //        Console.WriteLine();
        //    }

        //    Console.WriteLine("------------------");
        //}

        private static void MoveMiner()
        {
            if (commands.Length == 0)
            {
                isNotCommandsOver = false;
                return;
            }

            var command = commands[0];
            commands = commands.Skip(1).ToArray();

            switch (command)
            {
                case "up":
                    if (minerRow - 1 >= 0)
                    {
                        if (matrix[minerRow - 1][minerCol] == 'c')
                        {
                            totalColsCollected++;
                            leftCoal--;

                            CheckIsCoalLeftIsOver();
                        }
                        if (matrix[minerRow - 1][minerCol] == 'e')
                        {
                            isNotStepOnE = false;
                        }

                        matrix[minerRow][minerCol] = '*';
                        matrix[minerRow - 1][minerCol] = 's';
                        minerRow -= 1;
                    }
                    break;
                case "right":
                    if (minerCol + 1 <= matrix.Length - 1)
                    {
                        if (matrix[minerRow][minerCol + 1] == 'c')
                        {
                            totalColsCollected++;
                            leftCoal--;
                            CheckIsCoalLeftIsOver();
                        }
                        if (matrix[minerRow][minerCol + 1] == 'e')
                        {
                            isNotStepOnE = false;
                        }

                        matrix[minerRow][minerCol] = '*';
                        matrix[minerRow][minerCol + 1] = 's';
                        minerCol += 1;
                    }
                    break;
                case "left":
                    if (minerCol - 1 >= 0)
                    {
                        if (matrix[minerRow][minerCol - 1] == 'c')
                        {
                            totalColsCollected++;
                            leftCoal--;
                            CheckIsCoalLeftIsOver();
                        }
                        if (matrix[minerRow][minerCol - 1] == 'e')
                        {
                            isNotStepOnE = false;
                        }

                        matrix[minerRow][minerCol] = '*';
                        matrix[minerRow][minerCol - 1] = 's';
                        minerCol -= 1;
                    }
                    break;
                case "down":
                    if (minerRow + 1 <= matrix.Length - 1)
                    {
                        if (matrix[minerRow + 1][minerCol] == 'c')
                        {
                            totalColsCollected++;
                            leftCoal--;
                            CheckIsCoalLeftIsOver();
                        }
                        if (matrix[minerRow + 1][minerCol] == 'e')
                        {
                            isNotStepOnE = false;
                        }

                        matrix[minerRow][minerCol] = '*';
                        matrix[minerRow + 1][minerCol] = 's';
                        minerRow += 1;
                    }
                    break;
            }
        }

        private static void CheckIsCoalLeftIsOver()
        {
            if (leftCoal == 0)
            {
                isNotCollectAllCoals = false;
            }
        }

        private static void Fillmatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (input[col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (input[col] == "c")
                    {
                        leftCoal++;
                    }

                    matrix[row][col] = char.Parse(input[col]);
                }
            }
        }
    }
}
