using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BankAccount
{
    private int id;
    private double balance;



    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public double Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            //Validation
            if(value < 0)
            {
                throw new ArgumentException("Balance cannot be less than a zero!");
            }

            this.balance = value;
        }
    }


    public void Deposit(double amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.id}, balance {this.balance:f2}";
    }
}

