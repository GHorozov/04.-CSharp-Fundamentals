using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputRows = input[0];
            var inputCols = input[1];

            int[][] matrix = new int[input[0]][];

            // add matrix with elements.
            var counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[input[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }

            var commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                var currentCommand = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var columnOrRow = int.Parse(currentCommand[0]);
                var direction = currentCommand[1];
                var move = int.Parse(currentCommand[2]);

                if(direction == "up" || direction == "down")
                {
                    if(direction == "up")
                    {
                        MoveColumns(matrix, columnOrRow, move);
                    }
                    else if(direction == "down")
                    {
                        MoveColumns(matrix, columnOrRow, inputRows - move % inputRows); // The formula (inputCols - move % inputCols) is to avoid negative values.
                    }
                }
                else 
                {
                    if(direction == "left")
                    {
                        MoveRows(matrix, columnOrRow, move);
                    }
                    else if(direction == "right")
                    {
                        MoveRows(matrix, columnOrRow, inputCols - move % inputCols); // The formula (inputCols - move % inputCols) is to avoid negative values.
                    }
                }

            }

            var countElement = 1;
            for (int row= 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == countElement)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[r].Length; c++)
                            {
                                if(matrix[r][c] == countElement)
                                {
                                    var currentElement = matrix[row][col]; 
                                    matrix[row][col] = countElement; // change current element with element that have to be on position matrix[row][col].
                                    matrix[r][c] = currentElement; // current element is moving to other element position.

                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                }
                            }
                        }
                    }

                    countElement++;
                }
            }

        }

        private static void MoveRows(int[][] matrix, int columnOrRow, int move)
        {
            //move elements
            var temp = new int[matrix[0].Length];
            for (int col = 0; col < matrix[0].Length; col++)
            {
                temp[col] = matrix[columnOrRow][(col+move) % matrix[0].Length];
            }

            matrix[columnOrRow] = temp; //save changes to matrix.
        }

        private static void MoveColumns(int[][] matrix, int columnOrRow, int move)
        {
            //move elements
            var temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + move) % matrix.Length][columnOrRow];
            }

            //save changes to matrix.
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][columnOrRow] = temp[row];
            }
        }
    }
}
