using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];
            var matrixTwo = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix[i] = line;
            }

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();

                matrixTwo[i] = line;
            }


            var result = true;
            var length = matrix[0].Length + matrixTwo[0].Length;
            for (int i = 0; i < n; i++)
            {
                if(matrix[i].Length+matrixTwo[i].Length != length)
                {
                    result = false;
                    break;
                }
            }


            if (result)
            {
                var resultMatrix = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    resultMatrix[i] = new int[length];
                    resultMatrix[i] = matrix[i].Concat(matrixTwo[i]).ToArray();
                }

                for (int row = 0; row < resultMatrix.Length; row++)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ", resultMatrix[row]));
                    Console.WriteLine("]");
                }
            }
            else
            {
                var sum = 0;
                for (int row = 0; row < n; row++)
                {
                    sum += matrix[row].Length + matrixTwo[row].Length;
                }

                Console.WriteLine($"The total number of cells is: {sum}");

            }

        }
    }
}
