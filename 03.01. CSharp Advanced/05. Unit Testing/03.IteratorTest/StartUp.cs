namespace _03.IteratorTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            ListIterator list = null;
            string input;
            while ((input = Console.ReadLine())!= "END")
            {
                try
                {
                    var command = input.Split(" ").ToList();
                    switch (command[0])
                    {
                        case "Create":
                            list = new ListIterator(command.Skip(1).ToList());
                            break;
                        case "Move":
                            Console.WriteLine(list.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(list.HasNext());
                            break;
                        case "Print":
                            list.Print();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
