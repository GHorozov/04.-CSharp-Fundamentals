namespace _13.TupleTask
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var name = input[0] + " " + input[1];
            var address = input[2];
            Tuple<string, string> tuple1 = new Tuple<string, string>(name, address);
            Console.WriteLine(tuple1.Item1 +" -> " + tuple1.Item2);

            var secondLine = Console.ReadLine().Split(" ");
            name = secondLine[0];
            var number = int.Parse(secondLine[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name, number);
            Console.WriteLine(tuple2.Item1 + " -> " + tuple2.Item2);

            var thirthLine = Console.ReadLine().Split(" ");
            var numberInt = int.Parse(thirthLine[0]);
            var numberDouble = double.Parse(thirthLine[1]);
            Tuple<int, double> tuple3 = new Tuple<int, double>(numberInt, numberDouble);
            Console.WriteLine(tuple3.Item1 + " -> " + tuple3.Item2);
        }
    }
}
