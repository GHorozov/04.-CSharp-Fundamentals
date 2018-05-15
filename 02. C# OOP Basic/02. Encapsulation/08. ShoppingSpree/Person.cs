using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProduct;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProduct = new List<Product>();
    }


    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get { return this.money; }
        set
        {
            if(value < 0)
            {
                throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
            }

            this.money = value;
        }
    }

    public List<Product> BagOfProduct
    {
        get { return this.bagOfProduct; }
    }
    public void BuyProduct(Product product)
    {
        if(product.Cost <= this.Money)
        {
            this.Money -= product.Cost;
            this.bagOfProduct.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
    }
}

