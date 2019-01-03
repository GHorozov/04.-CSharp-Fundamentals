namespace _11.CustomListSorter
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var customCollection = new CustomCollection<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split(" ");
                var command = lineParts[0];

                switch (command)
                {
                    case "Add":
                        var element = lineParts[1];
                        customCollection.Add(element);
                        break;
                    case "Max":
                        Console.WriteLine(customCollection.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customCollection.Min());
                        break;
                    case "Greater":
                        var elementInput = lineParts[1];
                        Console.WriteLine(customCollection.Greater(elementInput));
                        break;
                    case "Swap":
                        var index1 = int.Parse(lineParts[1]);
                        var index2 = int.Parse(lineParts[2]);
                        customCollection.Swap(index1, index2);
                        break;
                    case "Contains":
                        var elementToContain = lineParts[1];
                        Console.WriteLine(customCollection.Contains(elementToContain));
                        break;
                    case "Remove":
                        var index = int.Parse(lineParts[1]);
                        customCollection.Remove(index);
                        break;
                    case "Print":
                        Console.WriteLine(customCollection.Print());
                        break;
                    case "Sort":
                        customCollection.Sort();
                        break;
                    default:
                        throw new InvalidOperationException("Wrong command!Try again!");
                }
            }
        }
    }
}
