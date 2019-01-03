namespace _06.Collection
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var lineParts = input.Split(" ");
                var command = lineParts[0];

                switch (command)
                {
                    case "Create":
                        var collection = lineParts.Skip(1).ToArray();
                        listyIterator = new ListyIterator<string>(collection);
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator?.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator?.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                }
            }
        }
    }
}
