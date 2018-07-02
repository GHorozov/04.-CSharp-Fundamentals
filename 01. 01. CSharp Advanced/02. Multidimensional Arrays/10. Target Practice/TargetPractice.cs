namespace _10._Target_Practice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TargetPractice
    {
        private static char[,] matrix;
        private static int rowsNumber;
        private static int colsNumber;
        private static int impactRow;
        private static int impactCol;
        private static int raduis;
        private static Queue<char> snake;

        static void Main(string[] args)
        {
            var demensions = Console.ReadLine()
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            rowsNumber = demensions[0];
            colsNumber = demensions[1];
            snake = new Queue<char>(Console.ReadLine().ToCharArray());
            var shot = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            impactRow = shot[0];
            impactCol = shot[1];
            raduis = shot[2];

            matrix = new char[rowsNumber, colsNumber];

            FillMatrix();

            ShotFire();

            AfterShot();

            PrintMatrix();

        }

        private static void AfterShot()
        {
            while (true)
            {
                var isFalling = false;
                for (int row = 0; row < rowsNumber - 1; row++)
                {
                    for (int col = 0; col < colsNumber; col++)
                    {
                        if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                            isFalling = true;
                        }
                    }
                }

                if (!isFalling)
                {
                    break;
                }
            }



            //Second way
            //for (int k = 0; k < matrix.GetLength(0); k++)
            //{
            //    for (int i = matrix.GetLength(0) - 1; i > 0; i--)
            //    {
            //        for (int j = 0; j < matrix.GetLength(1); j++)
            //        {
            //            if (matrix[i, j] == ' ')
            //            {
            //                char temp = matrix[i, j];
            //                matrix[i, j] = matrix[i - 1, j];
            //                matrix[i - 1, j] = temp;
            //            }
            //        }
            //    }
            //}
        }

        private static void ShotFire()
        {
            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < colsNumber; col++)
                {
                    var distance = Math.Pow((row - impactRow), 2) + Math.Pow((col - impactCol), 2);
                    if (distance <= Math.Pow(raduis, 2))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < colsNumber; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            for (int row = rowsNumber - 1; row >= 0; row--)
            {
                for (int col = colsNumber - 1; col >= 0; col--)
                {
                    matrix[row,col] = snake.Dequeue();
                    snake.Enqueue(matrix[row,col]);
                }

                row--;

                if (row < 0)
                {
                    break;
                }

                for (int col = 0; col < colsNumber; col++)
                {
                    matrix[row,col] = snake.Dequeue();
                    snake.Enqueue(matrix[row,col]);
                }
            }
        }
    }
}
