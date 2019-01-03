namespace _14.Threeuple
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split();
            var tuple1 = new Threeuple<string, string, string>(line1[0] + " " + line1[1], line1[2], line1[3]);
            Console.WriteLine(tuple1.Item1 + " -> " + tuple1.Item2 + " -> "+ tuple1.Item3);

            var line2 = Console.ReadLine().Split();
            var tuple2 = new Threeuple<string, int, string>(line2[0], int.Parse(line2[1]), line2[2] == "drunk" ? "True": "False");
            Console.WriteLine(tuple2.Item1 + " -> " + tuple2.Item2 + " -> " + tuple2.Item3);

            var line3 = Console.ReadLine().Split();
            var tuple3 = new Threeuple<string, double, string>(line3[0], double.Parse(line3[1]), line3[2]);
            Console.WriteLine(tuple3.Item1 + " -> " + tuple3.Item2 + " -> " + tuple3.Item3);
        }
    }
}
