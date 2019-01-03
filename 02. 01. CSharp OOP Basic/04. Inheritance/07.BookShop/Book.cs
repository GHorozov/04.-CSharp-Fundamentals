using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        protected set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }


    public string Title
    {
        get { return title; }
        protected set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }


    public string Author
    {
        get { return author; }
        protected set
        {
            var indexOfSpace = value.IndexOf(' ');

            if (indexOfSpace > 0 && indexOfSpace < value.Length - 1 && char.IsDigit(value[indexOfSpace + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().TrimEnd();
    }
}

