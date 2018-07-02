namespace _09._Rubiks_Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    class RubiksMatrix
    {
        private static int[,] matrix;
        private static int rowsNumber;
        private static int colsNumber;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
            rowsNumber = input[0];
            colsNumber = input[1];
            var n = int.Parse(Console.ReadLine());
            matrix = new int[rowsNumber, colsNumber];

            FillMatrix(matrix);

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var index = int.Parse(command[0]);
                var direction = command[1];
                var rotations = int.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                        ShiftColumn(index, colsNumber - rotations);
                        break;
                    case "down":
                        ShiftColumn(index, rotations);
                        break;
                    case "left":
                        ShiftRow(index, rowsNumber - rotations);
                        break;
                    case "right":
                        ShiftRow(index, rotations);
                        break;
                }

            }

            string result = RearrangeMatrix();
            Console.WriteLine(result);
        }

        private static string RearrangeMatrix()
        {
            var sb = new StringBuilder();
            var expectedNumber = 1;
            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < colsNumber; col++)
                {
                    if (matrix[row, col] == expectedNumber)
                    {
                        sb.AppendLine("No swap required"); 
                        expectedNumber++;
                    }
                    else
                    {
                        for (int r = row; r < rowsNumber; r++)
                        {
                            for (int c = 0; c < colsNumber; c++)
                            {
                                if (matrix[r, c] == expectedNumber)
                                {
                                    var temp = matrix[row, col];
                                    matrix[row, col] = matrix[r,c];
                                    matrix[r, c] = temp;

                                    sb.AppendLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }

                        expectedNumber++;
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void ShiftRow(int index, int rotations)
        {
            rotations %= colsNumber;

            var temp = new int[colsNumber];

            for (int i = 0; i < colsNumber; i++)
            {
                var indexToReplace = i - rotations;

                if (indexToReplace < 0)
                {
                    indexToReplace += colsNumber;
                }

                indexToReplace %= colsNumber;

                temp[i] = matrix[index, indexToReplace];
            }

            for (int i = 0; i < colsNumber; i++)
            {
                matrix[index, i] = temp[i]; 
            }

        }

        private static void ShiftColumn(int index, int rotations)
        {
            rotations %= rowsNumber;

            var temp = new int[rowsNumber];

            for (int i = 0; i < rowsNumber; i++)
            {
                var indexToReplace = i - rotations;

                if (indexToReplace < 0)
                {
                    indexToReplace += rowsNumber;
                }

                indexToReplace %= rowsNumber;

                temp[i] = matrix[indexToReplace, index];
            }

            for (int i = 0; i < rowsNumber; i++)
            {
                matrix[i, index] = temp[i];
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            var counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter++;
                }
            }
        }
    }
}
