namespace _09.GenericCountMethodDouble
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var box = new Box<double>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var element = double.Parse(Console.ReadLine());
                box.AddItem(element);
            }
            var elementToCompareWith = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CompareByValue<double>(elementToCompareWith));
        }
    }
}
