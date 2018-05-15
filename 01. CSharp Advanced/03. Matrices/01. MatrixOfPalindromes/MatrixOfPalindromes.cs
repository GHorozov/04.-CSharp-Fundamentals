using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            var alfabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[][] matrix = new string[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[input[1]];

                for (int col= 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = $"{alfabet[row]}{alfabet[row + col]}{alfabet[row]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

        }
    }
}
