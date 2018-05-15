using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BankAccountTest
{
    static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();
        var input = Console.ReadLine();

        while (input != "End")
        {
            var lineParts = input.Split(' ');
            var command = lineParts[0];


            switch (command)
            {
                case "Create":
                    Create(lineParts, accounts);
                    break;
                case "Deposit":
                    Deposit(lineParts, accounts);
                    break;
                case "Withdraw":
                    Withdraw(lineParts, accounts);
                    break;
                case "Print":
                    Print(lineParts, accounts);
                    break;

                default:
                    break;
            }


            input = Console.ReadLine();
        }
    }

    private static void Print(string[] lineParts, Dictionary<int, BankAccount> accounts)
    {
        var clientId = int.Parse(lineParts[1]);

        if (accounts.ContainsKey(clientId))
        {
            Console.WriteLine(accounts[clientId].ToString());
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
    private static void Withdraw(string[] lineParts, Dictionary<int, BankAccount> accounts)
    {
        var clientId = int.Parse(lineParts[1]);
        var amount = double.Parse(lineParts[2]);

        if (accounts.ContainsKey(clientId))
        {
            if (accounts[clientId].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[clientId].Withdraw(amount);            
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] lineParts, Dictionary<int, BankAccount> accounts)
    {
        var clientId = int.Parse(lineParts[1]);
        var amount = double.Parse(lineParts[2]);

        if (accounts.ContainsKey(clientId))
        {
            accounts[clientId].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] lineParts, Dictionary<int, BankAccount> accounts)
    {
        var clientId = int.Parse(lineParts[1]);

        if (accounts.ContainsKey(clientId))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = clientId;

            accounts.Add(clientId, acc);
        }
    }
}

