using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager = new DraftManager();

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = input[0];
            var allParams = input.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(allParams));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(allParams));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(allParams));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(allParams));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    Environment.Exit(0);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
