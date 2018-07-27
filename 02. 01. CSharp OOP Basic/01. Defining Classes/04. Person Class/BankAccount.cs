using System;

public class BankAccount
{
    private int id;
    private decimal balance;

    public decimal Balance { get => balance; set => balance = value; }
    public int Id { get => id; set => id = value; }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (this.balance - amount < 0)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            this.balance -= amount;
        }
    }

    public override string ToString()
    {
        return $"Account ID{this.id}, balance {this.balance:f2}";
    }
}