namespace _07.JediGalaxy
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xEvil = evil[0];
                int yEvil = evil[1];

                ModifyEvil(matrix, xEvil, yEvil);

                int xIvo = ivoS[0];
                int yIvo = ivoS[1];

                sum = ModifyIvo(matrix, sum, xIvo, yIvo);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long ModifyIvo(int[,] matrix,  long sum,  int xIvo,  int yIvo)
        {
            while (xIvo >= 0 && yIvo < matrix.GetLength(1))
            {
                if (IsInside(xIvo, yIvo, matrix))
                {
                    sum += matrix[xIvo, yIvo];
                }

                yIvo++;
                xIvo--;
            }

            return sum;
        }
     
        private static void ModifyEvil(int[,] matrix,int xEvil, int yEvil)
        {
            while (xEvil >= 0 && yEvil >= 0)
            {
                if (IsInside(xEvil, yEvil, matrix))
                {
                    matrix[xEvil, yEvil] = 0;
                }
                xEvil--;
                yEvil--;
            }
        }

        private static bool IsInside(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
