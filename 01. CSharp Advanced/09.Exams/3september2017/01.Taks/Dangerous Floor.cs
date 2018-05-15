using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DangerousFloor
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {
            var matrix = new string[8, 8];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input;
                var typeOfPiece = lineParts[0].ToString();
                var currentRow = int.Parse(lineParts[1].ToString());
                var currentCol = int.Parse(lineParts[2].ToString());
                var newRow = int.Parse(lineParts[4].ToString());
                var newCol = int.Parse(lineParts[5].ToString());


                if (!CheckIsPieceIsThere(matrix, currentRow, currentCol, typeOfPiece))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (!IsInMatrix(matrix, newRow, newCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }


                //-------------------------------------------------------------------------------------------
                //Check for king.
                if (typeOfPiece == "K")//цар
                {
                    if (Math.Abs(newRow - currentRow) <= 1 && Math.Abs(newCol - currentCol) <= 1)
                    {
                        matrix[newRow, newCol] = "K";
                        matrix[currentRow, currentCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (typeOfPiece == "R")//топ
                {

                    if (newRow == currentRow || newCol == currentCol)
                    {
                        matrix[newRow, newCol] = "R";
                        matrix[currentRow, currentCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
                else if (typeOfPiece == "B")//офицер
                {

                    if (Math.Abs(currentRow - newRow) == Math.Abs(currentCol - newCol) || (currentRow + currentCol) == (newRow + newCol))
                    {
                        matrix[newRow, newCol] = "B";
                        matrix[currentRow, currentCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }

                }
                else if (typeOfPiece == "Q")//царица
                {

                    if (Math.Abs(currentRow - newRow) == Math.Abs(currentCol - newCol) || ((currentRow + currentCol) == (newRow + newCol)) || currentRow == newRow || currentCol == newCol)
                    {
                        matrix[newRow, newCol] = "Q";
                        matrix[currentRow, currentCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }

                }
                else if (typeOfPiece == "P")//пешка
                {
                    if (currentRow - newRow == 1 && currentCol == newCol)
                    {
                        matrix[newRow, newCol] = "P";
                        matrix[currentRow, currentCol] = "x";
                    }
                    else
                    {
                        Console.WriteLine("Invalid move!");
                    }
                }
            }

        }

        private static bool IsInMatrix(string[,] matrix, int newMoveRow, int newMoveCol)
        {
            if (newMoveRow >= 0 && newMoveRow < matrix.GetLength(0) && newMoveCol >= 0 && newMoveCol < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIsPieceIsThere(string[,] matrix, int pieceRow, int pieceCol, string typeOfPiece)
        {
            return matrix[pieceRow, pieceCol] == typeOfPiece;
        }
    }
}
