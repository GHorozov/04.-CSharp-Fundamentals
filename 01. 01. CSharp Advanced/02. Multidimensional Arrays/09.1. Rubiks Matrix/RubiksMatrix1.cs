namespace _09._1._Rubiks_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class RubiksMatrix1
    {
        private static int[,] matrix;
        private static int rowsNumber = 0;
        private static int colsNumber = 0;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            rowsNumber = input[0];
            colsNumber = input[1];
            var n = int.Parse(Console.ReadLine());
            matrix = new int[rowsNumber, colsNumber];

            FillTheMatrix(matrix);

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var index = int.Parse(command[0]);
                var direction = command[1];
                var rotations = int.Parse(command[2]);


                switch (direction)
                {
                    case "up":
                        ShiftColumn(index, rotations % rowsNumber, "up");
                        break;
                    case "down":
                        ShiftColumn(index, rotations % rowsNumber, "down");
                        break;
                    case "left":
                        ShiftRow(index, rotations % colsNumber, "left");
                        break;
                    case "right":
                        ShiftRow(index, rotations % colsNumber, "right");
                        break;
                    default:
                        break;
                }

            }

            var result = RearrangeMatrix();
            Console.WriteLine(result);
        }

        private static string RearrangeMatrix()
        {
            var sb = new StringBuilder();
            var comparingNumber = 1;

            for (int row = 0; row < rowsNumber; row++)
            {
                for (int col = 0; col < colsNumber; col++)
                {
                    if(matrix[row,col] == comparingNumber)
                    {
                        sb.AppendLine("No swap required");
                        comparingNumber++;
                        continue;
                    }
                    else
                    {
                        for (int i = row; i < rowsNumber; i++)
                        {
                            for (int j = 0; j < colsNumber; j++)
                            {
                                if(matrix[i,j] == comparingNumber)
                                {
                                    var temp = matrix[row, col];
                                    matrix[row, col] = matrix[i, j];
                                    matrix[i, j] = temp;
                                    sb.AppendLine($"Swap ({row}, {col}) with ({i}, {j})");
                                    break;
                                }
                            }
                        }
                    }

                    comparingNumber++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void ShiftRow(int index, int rotations, string route)
        {
            var queue = new Queue<int>();

            if(route == "left")
            {
                for (int i = 0; i < colsNumber; i++)
                {
                    queue.Enqueue(matrix[index, i]);
                }

                for (int i = 0; i < rotations; i++)
                {
                    var number = queue.Dequeue();
                    queue.Enqueue(number);
                }

                for (int i = 0; i < colsNumber; i++)
                {
                    matrix[index, i] = queue.Dequeue();
                }
            }
            else 
            {
                for (int i = colsNumber - 1; i >= 0; i--)
                {
                    queue.Enqueue(matrix[index, i]);
                }

                for (int i = 0; i < rotations; i++)
                {
                    var number = queue.Dequeue();
                    queue.Enqueue(number);
                }

                for (int i = colsNumber - 1; i >= 0; i--)
                {
                    matrix[index, i] = queue.Dequeue();
                }
            }
           

           
        }

        private static void ShiftColumn(int index, int rotations, string route)
        {
            var queue = new Queue<int>();

            if(route  == "up")
            {
                for (int i = 0; i < rowsNumber; i++)
                {
                    queue.Enqueue(matrix[i, index]);
                }

                for (int i = 0; i < rotations; i++)
                {
                    var number = queue.Dequeue();
                    queue.Enqueue(number);
                }

                for (int i = 0; i < rowsNumber; i++)
                {
                    matrix[i, index] = queue.Dequeue();
                }
            }
            else
            {
                for (int i = rowsNumber - 1; i >= 0; i--)
                {
                    queue.Enqueue(matrix[i, index]);
                }

                for (int i = 0; i < rotations; i++)
                {
                    var number = queue.Dequeue();
                    queue.Enqueue(number);
                }

                for (int i = rowsNumber - 1; i >= 0; i--)
                {
                    matrix[i, index] = queue.Dequeue();
                }
            }
        }

        private static void FillTheMatrix(int[,] matrix)
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
