namespace _14._The_Heigan_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TheHeiganDance
    {
        const int MatrixRowSize = 15;
        const int MatrixColSize = 15;
        private static double player;
        private static double heigan;
        private static Queue<double> damageLeft;
        private static int positionRow;
        private static int positionCol;
        private static double damageToHeigan;
        private static string currentSpell;
        
        static void Main(string[] args)
        {
            damageToHeigan = double.Parse(Console.ReadLine());
            player = 18500;
            heigan = 3000000;
            damageLeft = new Queue<double>();
            positionRow = 7;
            positionCol = 7;
            currentSpell = string.Empty;

            ExecuteDance();
        }

        private static void ExecuteDance()
        {
            while (true)
            {
                if (damageLeft.Count > 0)
                {
                    player -= damageLeft.Dequeue();
                }

                heigan -= damageToHeigan;
                IsDanceOver();

                var input = Console.ReadLine().Split().ToArray();
                currentSpell = input[0];
                var targetRow = int.Parse(input[1]);
                var targetCol = int.Parse(input[2]);
                
                if (IsInRangeInDamage(targetRow, targetCol) && !CanIEscape(targetRow, targetCol))
                {
                    switch (currentSpell)
                    {
                        case "Cloud":
                            player -= 3500;
                            damageLeft.Enqueue(3500);                 
                            break;
                        case "Eruption":
                            player -= 6000;
                            break;
                    }

                    IsDanceOver();
                }         
            }
        }

        private static void IsDanceOver()
        {
            if (player < 0 || heigan < 0)
            {
                if (currentSpell == "Cloud")
                {
                    currentSpell = "Plague Cloud";
                }

                Console.WriteLine(heigan > 0 ? $"Heigan: {heigan:f2}" : $"Heigan: Defeated!");
                Console.WriteLine(player > 0 ? $"Player: {player}" : $"Player: Killed by {currentSpell}");
                Console.WriteLine($"Final position: {positionRow}, {positionCol}");
                Environment.Exit(0);
            }
        }

        private static bool CanIEscape(int targetRow, int targetCol)
        {
            if (positionRow == targetRow && positionCol == targetCol)
            {
                return false;
            }

            var cellRoofBorder = targetRow - 1;
            var cellRightBorder = targetCol + 1;
            var cellDownBorder = targetRow + 1;
            var cellLeftBorder = targetCol - 1;

            //up
            if (positionRow - 1 >= 0 && positionRow - 1 < cellRoofBorder)
            {
                positionRow = positionRow - 1;
                return true;
            }
            //right
            if (positionCol + 1 < MatrixColSize && positionCol + 1 > cellRightBorder)
            {
                positionCol = positionCol + 1;
                return true;
            }

            //down
            if (positionRow + 1 < MatrixRowSize && positionRow + 1 > cellDownBorder)
            {
                positionRow = positionRow + 1;
                return true;
            }

            //left
            if (positionCol - 1 >= 0 && positionCol - 1 < cellLeftBorder)
            {
                positionCol = positionCol - 1;
                return true;
            }

            return false;
        }

        private static bool IsInRangeInDamage(int targetRow, int targetCol)
        {
            return positionRow >= targetRow - 1 && positionRow <= targetRow + 1 && positionCol >= targetCol - 1 && positionCol <= targetCol + 1;
        }
    }
}
