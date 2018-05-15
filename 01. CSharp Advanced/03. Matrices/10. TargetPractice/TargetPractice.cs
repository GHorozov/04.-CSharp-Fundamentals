using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numberOfRows = input[0];
            var numberOfCols = input[1];
            var snake = Console.ReadLine();

            var matrix = new char[numberOfRows][];

            FillMatrix(numberOfCols, snake, matrix);


            var shotInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var shotRow = shotInput[0];
            var shotCol = shotInput[1];
            var radius = shotInput[2];

            ShotFire(matrix, shotRow, shotCol, radius);

            for (int col = 0; col < numberOfCols; col++)
            {
                GravityInAction(matrix, col);
            }
            

            PrintMatrix(matrix);
        }

        private static void GravityInAction(char[][] matrix, int col)
        {
            while (true)
            {
                var IsNotEnd = false;

                for (int row = 1; row < matrix.Length; row++)
                {
                    var topCell = matrix[row - 1][col];
                    var downCell = matrix[row][col];

                    if (downCell == ' ' && topCell != ' ')
                    {
                        matrix[row][col] = topCell;
                        matrix[row - 1][col] = ' ';
                        IsNotEnd = true;
                    }
                }

                if(!IsNotEnd )
                {
                    break;
                }
            }
        }

        private static void ShotFire(char[][] matrix, int shotRow, int shotCol, int radius)
        {
            //(x - center_x)^2 + (y - center_y)^2 < radius^2

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    //check each cell whether cell is in inpact radius.
                    if ((col - shotCol) * (col - shotCol) + (row - shotRow) * (row - shotRow) <= radius * radius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void FillMatrix(int numberOfCols, string snake, char[][] matrix)
        {
            var snakeIndex = 0;
            var movement = 1;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[numberOfCols];

                if (movement % 2 == 1)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row][col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }

                movement++;
            }
        }
    }
}
