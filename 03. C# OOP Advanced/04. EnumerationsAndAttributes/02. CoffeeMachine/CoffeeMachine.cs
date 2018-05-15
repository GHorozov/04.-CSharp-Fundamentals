using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CoffeeMachine
{
    private int coins;
    private IList<CoffeeType> coffeeSold;

    public CoffeeMachine()
    {
        this.coffeeSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeeSold
    {
        get
        {
            return this.coffeeSold;
        }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        if(this.coins >= (int)coffeePrice)
        {
            coffeeSold.Add(coffeeType);
            this.coins = 0;
        }
        else
        {
            throw new ArgumentException("Not enough money!");
        }
    }

    public void InsertCoin(string coin)
    {
        Coin coinType = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)coinType;
    }
}

