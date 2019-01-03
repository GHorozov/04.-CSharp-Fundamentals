namespace _03.Task
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[][] matrix;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new int[n][];
            FillMatrix();
            var coordinates = Console.ReadLine().Split();

            foreach (var item in coordinates)
            {
                var args = item.Split(",");
                var targetRow = int.Parse(args[0]);
                var targetCol = int.Parse(args[1]);

                if(matrix[targetRow][targetCol] <= 0)
                {
                    continue;
                }

                ExplodeCell(targetRow, targetCol);
            }

            var aliveCells = matrix.SelectMany(x => x).Where(x => x > 0).Count();
            var sumAllSells = matrix.SelectMany(x => x).Where(x => x > 0).Sum();
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAllSells}");
            PrintMatrix();
        }

        private static void ExplodeCell(int targetRow, int targetCol)
        {
            var cellPower = matrix[targetRow][targetCol];

            //up
            if (IsInMatrix(targetRow - 1, targetCol - 1) && matrix[targetRow - 1][targetCol - 1] > 0)
            {
                matrix[targetRow - 1][targetCol - 1] -= cellPower;
            }
            if (IsInMatrix(targetRow - 1, targetCol) && matrix[targetRow - 1][targetCol] > 0)
            {
                matrix[targetRow - 1][targetCol] -= cellPower;
            }
            if (IsInMatrix(targetRow - 1, targetCol + 1) && matrix[targetRow - 1][targetCol + 1] > 0)
            {
                matrix[targetRow - 1][targetCol + 1] -= cellPower;
            }

            //center
            if (IsInMatrix(targetRow, targetCol - 1) && matrix[targetRow][targetCol - 1] > 0)
            {
                matrix[targetRow][targetCol - 1] -= cellPower;
            }

            //bomb
            matrix[targetRow][targetCol] = 0;

            if (IsInMatrix(targetRow, targetCol + 1) && matrix[targetRow][targetCol +1] > 0)
            {
                matrix[targetRow][targetCol + 1] -= cellPower;
            }

            //down
            if (IsInMatrix(targetRow + 1, targetCol - 1) && matrix[targetRow + 1][targetCol - 1] > 0)
            {
                matrix[targetRow+1][targetCol - 1] -= cellPower;
            }
            if (IsInMatrix(targetRow + 1, targetCol) && matrix[targetRow + 1][targetCol] > 0)
            {
                matrix[targetRow + 1][targetCol] -= cellPower;
            }
            if (IsInMatrix(targetRow + 1, targetCol + 1) && matrix[targetRow + 1][targetCol + 1] > 0)
            {
                matrix[targetRow + 1][targetCol + 1] -= cellPower;
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ") ;
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split().ToArray();
                matrix[row] = new int[input.Length];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = int.Parse(input[col]);
                }
            }
        }
    }
}
