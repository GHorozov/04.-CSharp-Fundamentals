namespace _08.GenericCountMethodString
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var element = Console.ReadLine();
                box.AddItem(element);
            }
            var elementToCompareWith = Console.ReadLine();
            Console.WriteLine(box.CompareByValue<string>(elementToCompareWith));
        }
    }
}
