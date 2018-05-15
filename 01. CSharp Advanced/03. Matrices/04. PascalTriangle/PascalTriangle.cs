using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascalTriangle[row] = new long[row+1]; // add new column with lenght row + 1.
                pascalTriangle[row][0] = 1; // add 1 to all rows to the beginning of each row.
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1; // add 1 to all rows to the end of each row;

                for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }

            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
