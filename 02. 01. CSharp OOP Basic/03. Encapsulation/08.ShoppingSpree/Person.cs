using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Products = new List<Product>();
    }

    public List<Product> Products
    {
        get { return products; }
        private set { products = value; }
    }

    public decimal Money
    {
        get
        {
            return money;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public string BuyProduct(Product product)
    {
        if (money >= product.Cost)
        {
            money -= product.Cost;
            this.products.Add(product);
            return $"{this.name} bought {product.Name}";
        }
        else
        {
            return $"{this.name} can't afford {product.Name}";
        }
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        if (products.Any())
        {
            sb.AppendLine($"{this.Name} - {string.Join(", ", this.products.Select(x => x.Name))}");
        }
        else
        {
            sb.AppendLine($"{this.Name} - Nothing bought");
        }

        return sb.ToString().TrimEnd();
    }
}

