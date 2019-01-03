namespace _05.GenericBoxOfInteger
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var element = int.Parse(Console.ReadLine());
                var box = new Box<int>(element);
                Console.WriteLine(box);
            }
        }
    }
}
