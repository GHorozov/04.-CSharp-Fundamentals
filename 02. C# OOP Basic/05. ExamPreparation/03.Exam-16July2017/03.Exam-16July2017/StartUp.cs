using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var draftManager = new DraftManager();

        while (true)
        {
            var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            try
            {
                switch (command[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draftManager.RegisterHarvester(command));
                        break;

                    case "RegisterProvider":
                        Console.WriteLine(draftManager.RegisterProvider(command));
                        break;

                    case "Day":
                        Console.WriteLine(draftManager.Day());
                        break;

                    case "Mode":
                        Console.WriteLine(draftManager.Mode(command));
                        break;

                    case "Check":
                        Console.WriteLine(draftManager.Check(command));
                        break;
                    case "Shutdown":
                        Console.WriteLine(draftManager.ShutDown());
                        Environment.Exit(0);
                        break;
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

