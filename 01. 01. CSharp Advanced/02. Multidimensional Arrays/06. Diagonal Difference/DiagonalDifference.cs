namespace _06._Diagonal_Difference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftDiagonal = 0;
            var rightDiagonal = 0;
          
            var matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine().Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = inputRow[col];
                }
            }

            for (int i = 0; i < n; i++)
            {
                leftDiagonal += matrix[i, i];
                rightDiagonal += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(leftDiagonal - rightDiagonal));
        }
    }
}
