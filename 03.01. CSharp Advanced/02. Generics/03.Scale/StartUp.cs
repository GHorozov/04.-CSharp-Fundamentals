namespace _03.Scale
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new Scale<string>("Gosho", "Pesho");
            Console.WriteLine(scale.GetHeavier());
        }
    }
}
