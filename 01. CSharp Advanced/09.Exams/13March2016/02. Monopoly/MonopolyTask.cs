using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Monopoly
{
    class MonopolyTask
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowsLength = input[0];
            var colsLength = input[1];

            var matrix = new char[rowsLength, colsLength];

            var turn = 0;
            var hotelNumber = 0;
            var playerMoney = 50;
            for (int row = 0; row < rowsLength; row++)
            {
                var currentInputLine = Console.ReadLine();
                for (int col = 0; col < colsLength; col++)
                {
                    matrix[row, col] = currentInputLine[col];
                }
            }


            for (int row = 0; row < rowsLength; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < colsLength; col++)
                    {
                        CalculateCharsMatrix(matrix, ref turn, ref hotelNumber, ref playerMoney, row, col);
                        playerMoney += hotelNumber * 10;
                    }
                }
                else
                {
                    for (int col = colsLength - 1; col >= 0; col--)
                    {
                        CalculateCharsMatrix(matrix, ref turn, ref hotelNumber, ref playerMoney, row, col);
                        playerMoney += hotelNumber * 10;
                    }
                }
            }

            Console.WriteLine($"Turns {turn}{Environment.NewLine}Money {playerMoney}");
        }

        private static void CalculateCharsMatrix(char[,] matrix, ref int turn, ref int hotelNumber, ref int playerMoney, int row, int col)
        {
            turn++;

            switch (matrix[row, col])
            {
                case 'H':
                    hotelNumber++;
                    Console.WriteLine($"Bought a hotel for {playerMoney}. Total hotels: {hotelNumber}.");

                    playerMoney = 0;
                    break;

                case 'J':
                    Console.WriteLine($"Gone to jail at turn {turn - 1}.");
                    turn += 2;
                    playerMoney += (hotelNumber * 10)*2;
                    break;

                case 'F':
                    break;

                case 'S':
                    var toSpend = (row + 1) * (col + 1);

                    if (playerMoney < toSpend)
                    {
                        toSpend = playerMoney;
                        playerMoney = 0;
                    }
                    else
                    {
                        playerMoney = playerMoney - toSpend;
                    }

                    Console.WriteLine($"Spent {toSpend} money at the shop.");
                    break;
            }
        }
    }
}
