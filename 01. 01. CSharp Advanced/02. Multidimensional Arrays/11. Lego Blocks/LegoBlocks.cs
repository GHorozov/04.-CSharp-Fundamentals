namespace _11._Lego_Blocks
{
    using System;
    using System.Linq;

    class LegoBlocks
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix1 = new int[n][];
            var matrix2 = new int[n][];
            var firstSum = ReadMatrix(n, matrix1);
            var secondSum = ReadMatrix(n, matrix2);
            var elementsCount = firstSum + secondSum;

            var lenghtRow = 0;
            for (int row = 0; row < n; row++)
            {
                var currentRowSum = matrix1[row].Length + matrix2[row].Length;

                if (row == 0)
                {
                    lenghtRow = currentRowSum;
                }

                if(currentRowSum != lenghtRow)
                {
                    Console.WriteLine($"The total number of cells is: {elementsCount}");
                    return;
                }
            }

            var matrix3 = new int[n][];

            for (int row = 0; row < matrix3.Length; row++)
            {
                var currentInputLenght = matrix1[row].Length + matrix2[row].Length;
                matrix3[row] = new int[currentInputLenght];

                var colCount = 0;

                for (int col = 0; col < matrix1[row].Length; col++)
                {
                    matrix3[row][col] = matrix1[row][col];
                    colCount++;
                }

                for (int col = matrix2[row].Length - 1; col >= 0; col--)
                {
                    matrix3[row][colCount++] = matrix2[row][col];
                }
            }

            PrintMatrix(matrix3);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine($"[{string.Join(", ", matrix[row])}]");
            }
        }

        private static int ReadMatrix(int n, int[][] matrix)
        {
            var sum = 0;
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var currentRow = new int[input.Length];
                sum += input.Length;
                matrix[row] = input;
            }

            return sum;
        }
    }
}
