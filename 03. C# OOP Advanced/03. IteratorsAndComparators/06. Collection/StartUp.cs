using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {

        ListyIterator<string> listyIterator = null;
        var input = Console.ReadLine();

        try
        {
            while (input != "END")
            {
                var command = input.Split(' ');

                switch (command[0])
                {
                    case "Create":
                        if (command.Length > 1)
                        {
                            listyIterator = new ListyIterator<string>(command.Skip(1).ToList());
                        }
                        else
                        {
                            listyIterator = new ListyIterator<string>();
                        }
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    case "PrintAll":
                        Console.WriteLine(listyIterator.PrintAll());
                        break;
                }

                input = Console.ReadLine();
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
