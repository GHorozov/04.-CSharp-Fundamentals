using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Book
{
    private const int titleSymbolLength = 3;
    private const int priceMinValue = 0;

    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }



    private string Author
    {
        get
        {
            return this.author;
        }

        set
        {
            var indexOfSpace = value.IndexOf(' ');

            if (indexOfSpace > 0 && indexOfSpace < value.Length - 1 && char.IsDigit(value[indexOfSpace + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    private string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            if (value.Length < titleSymbolLength)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    protected virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= priceMinValue)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f1}")
            .AppendLine();

        return sb.ToString();
    }

}

