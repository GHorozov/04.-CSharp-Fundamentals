using System;
using System.Collections.Generic;

public class BankAccountTest
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var commandArgs = input.Split();
            var command = commandArgs[0];

            switch (command)
            {
                case "Create":
                    var id = int.Parse(commandArgs[1]);
                    if (accounts.ContainsKey(id))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var acc = new BankAccount();
                        acc.Id = id;
                        accounts.Add(id, acc);
                    }
                    break;
                case "Deposit":
                    var depositId = int.Parse(commandArgs[1]);
                    var depositAmount = decimal.Parse(commandArgs[2]);
                    if (!accounts.ContainsKey(depositId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        accounts[depositId].Deposit(depositAmount);
                    }
                    break;
                case "Withdraw":
                    var withdrawId = int.Parse(commandArgs[1]);
                    var withdrawAmount = decimal.Parse(commandArgs[2]);
                    if (!accounts.ContainsKey(withdrawId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        accounts[withdrawId].Withdraw(withdrawAmount);
                    }
                    break;
                case "Print":
                    var printId = int.Parse(commandArgs[1]);
                    if (!accounts.ContainsKey(printId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        Console.WriteLine(accounts[printId]);
                    }
                    break;
            }
        }
    }
}

