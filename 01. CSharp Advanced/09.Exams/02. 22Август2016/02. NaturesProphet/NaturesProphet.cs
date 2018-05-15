using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturesProphet
{
    class NaturesProphet
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new int[input[0], input[1]];

            var inputLine = Console.ReadLine();
            while (inputLine != "Bloom Bloom Plow")
            {
                var line = inputLine.Split(' ').Select(int.Parse).ToArray();
                var rowLine = line[0];
                var colLine = line[1];

                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[rowLine,col]++;
                }

                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    matrix[row, colLine]++;
                }

                matrix[rowLine, colLine]--;

                inputLine = Console.ReadLine();
            }

            var sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.Append(matrix[i, j] + " ");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb);
        }
    }
}
