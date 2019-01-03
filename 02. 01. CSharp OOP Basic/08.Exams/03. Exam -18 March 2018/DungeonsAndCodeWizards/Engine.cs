using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DungeonMaster dm;

    public Engine()
    {
        dm = new DungeonMaster();
    }

    public void Run()
    {
        var operations = new List<string>();
        string input = Console.ReadLine();
        while (true)
        {
            if (string.IsNullOrEmpty(input))
            {
                break;
            }

            operations.Add(input);
            input = Console.ReadLine();
        }

        var isItOver = true;
        foreach (var operation in operations)
        {
            if (dm.IsGameOver())
            {
                Console.WriteLine(OutputMessage.FinalStats);
                Console.WriteLine(dm.GetStats());
                isItOver = false;
                break;
            }

            var inputArgs = operation.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var command = inputArgs[0];
            var args = inputArgs.Skip(1).ToArray();

            try
            {
                switch (command)
                {
                    case "JoinParty":
                        Console.WriteLine(dm.JoinParty(args));
                        break;
                    case "AddItemToPool":
                        Console.WriteLine(dm.AddItemToPool(args));
                        break;
                    case "PickUpItem":
                        Console.WriteLine(dm.PickUpItem(args));
                        break;
                    case "UseItem":
                        Console.WriteLine(dm.UseItem(args));
                        break;
                    case "UseItemOn":
                        Console.WriteLine(dm.UseItemOn(args));
                        break;
                    case "GiveCharacterItem":
                        Console.WriteLine(dm.GiveCharacterItem(args));
                        break;
                    case "GetStats":
                        Console.WriteLine(dm.GetStats());
                        break;
                    case "Attack":
                        Console.WriteLine(dm.Attack(args));
                        break;
                    case "Heal":
                        Console.WriteLine(dm.Heal(args));
                        break;
                    case "EndTurn":
                        Console.WriteLine(dm.EndTurn(args));
                        break;
                    default:
                        throw new InvalidOperationException("Wrong command!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Parameter Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Invalid Operation: " + ex.Message);
            }
        }

        if (isItOver)
        {
            Console.WriteLine(OutputMessage.FinalStats);
            Console.WriteLine(dm.GetStats());
        }
    }
}

