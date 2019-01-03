namespace _01.MathOperationsTask
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mathOperation = new MathOperations();
            Console.WriteLine(mathOperation.Add(2, 3));
            Console.WriteLine(mathOperation.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperation.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
