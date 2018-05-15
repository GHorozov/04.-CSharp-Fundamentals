using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    protected string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
            }

            if(value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(this.firstName)}");
            }

            this.firstName = value;
        }
    }

    protected string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if(char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.lastName)}");
            }

            if(value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: {nameof(lastName)}");
            }
            this.lastName = value;
        }
    }

}

