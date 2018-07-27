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
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.id}, balance {this.balance}";
    }
}

