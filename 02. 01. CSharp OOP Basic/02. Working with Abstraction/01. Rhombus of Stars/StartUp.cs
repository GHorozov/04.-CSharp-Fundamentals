namespace _01._Rhombus_of_Stars
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var starsCount = int.Parse(Console.ReadLine());

            for (int rowSize = 1; rowSize <= starsCount; rowSize++)
            {
                PrintRow(starsCount, rowSize);
            }

            for (int rowSize = starsCount - 1; rowSize >= 0; rowSize--)
            {
                PrintRow(starsCount, rowSize);
            }

        }

        private static void PrintRow(int starsCount, int rowSize)
        {
            for (int i = 0; i < starsCount - rowSize; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < rowSize; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
