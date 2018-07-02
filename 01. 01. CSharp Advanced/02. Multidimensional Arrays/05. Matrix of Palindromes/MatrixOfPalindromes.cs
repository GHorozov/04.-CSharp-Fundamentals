namespace _05._Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            var r = input[0];
            var c = input[1];
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
          
            var matrix = new string[r,c];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{alphabet[row]}{alphabet[row+col]}{alphabet[row]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
