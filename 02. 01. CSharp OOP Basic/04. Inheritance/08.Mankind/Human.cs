using System;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    protected string LastName
    {
        get { return lastName; }
        set
        {
            var firstLetter = value[0];

            if (char.IsLower(firstLetter))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.lastName)}");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: {nameof(this.lastName)}");
            }

            this.lastName = value;
        }
    }


    protected string FirstName
    {
        get { return firstName; }
        set
        {
            var firstLetter = value[0];

            if(char.IsLower(firstLetter))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(this.firstName)}");
            }

            firstName = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");

        return sb.ToString();
    }
}

