namespace _3._Group_Numbers
{
    using System;
    using System.Linq;

    class GroupNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var sizeArray = new int[3];
          
            foreach (var number in numbers)
            {
                sizeArray[Math.Abs(number % 3)]++;
            }

            var matrix = new int[3][];
            for (int i = 0; i < sizeArray.Length; i++)
            {
                matrix[i] = new int[sizeArray[i]];
            }

            var indexArray = new int[3];
            foreach (var number in numbers)
            {
                var reminder = Math.Abs(number % 3);
                matrix[reminder][indexArray[reminder]++] = number;
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
