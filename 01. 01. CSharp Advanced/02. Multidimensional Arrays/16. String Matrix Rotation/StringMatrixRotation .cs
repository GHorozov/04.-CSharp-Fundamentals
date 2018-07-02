namespace _16._String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;

    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var startIndex = input.IndexOf("(") + 1;
            var endPart = input.Substring(startIndex);
            var degreeNumber = int.Parse(endPart.TrimEnd(')'));
            var shift = (degreeNumber / 90) % 4;

            var maxCols = 0;
            var maxRows = 0;
            var listWords = new List<string>();
            var inputLines = Console.ReadLine();
            while (inputLines != "END")
            {
                maxRows++;
                if (inputLines.Length > maxCols)
                {
                    maxCols = inputLines.Length;
                }
                listWords.Add(inputLines);
                inputLines = Console.ReadLine();
            }

            var words = new Queue<char>();
            for (int i = 0; i < maxCols; i++)
            {
                for (int j = maxRows - 1; j >= 0; j--)
                {
                    if (listWords[j].Length <= i)
                    {
                        words.Enqueue(' ');
                    }
                    else
                    {
                        words.Enqueue(listWords[j][i]);
                    }
                }
            }

            var matrix = RotateMatrix(words, shift, maxRows, maxCols);

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] RotateMatrix(Queue<char> words, int shift, int maxRows, int maxCols)
        {
            char[,] matrix;

            if (shift == 0) //360 degrees
            {
                matrix = new char[maxRows, maxCols];

                for (int i = 0; i < maxCols; i++)
                {
                    for (int j = maxRows - 1; j >= 0; j--)
                    {
                        matrix[j, i] = words.Dequeue();
                    }
                }

                return matrix;
            }
            else if (shift == 1) //90 degrees
            {
                matrix = new char[maxCols, maxRows];

                for (int i = 0; i < maxCols; i++)
                {
                    for (int j = 0; j < maxRows; j++)
                    {
                        matrix[i, j] = words.Dequeue();
                    }
                }

                return matrix;
            }
            else if (shift == 2) //180 degrees
            {
                matrix = new char[maxRows, maxCols];

                for (int i = maxCols - 1; i >= 0; i--)
                {
                    for (int j = 0; j < maxRows; j++)
                    {
                        matrix[j, i] = words.Dequeue();
                    }
                }

                return matrix;
            }
            else if (shift == 3) //270 degrees
            {
                matrix = new char[maxCols, maxRows];

                for (int i = maxCols - 1; i >= 0; i--)
                {
                    for (int j = maxRows - 1; j >= 0; j--)
                    {
                        matrix[i, j] = words.Dequeue();
                    }
                }

                return matrix;
            }

            return null;
        }
    }
}
