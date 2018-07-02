namespace _4._Pascal_Triangle
{
    using System;

    class PascalTriangle
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var triangle = new long[n][];

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][row] = 1;
            }

            for (int row = 2; row < triangle.Length; row++)
            {
                for (int col = 1; col < triangle[row].Length-1; col++)
                {
                    if(triangle[row][col] == 0)
                    {
                        triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                    }
                }
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
