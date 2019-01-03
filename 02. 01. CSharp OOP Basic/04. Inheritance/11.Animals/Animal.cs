using System;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        set
        {
            ValidateInput(value);
            name = value;
        }
    }
   
    public int Age
    {
        get { return age; }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            ValidateInput(value);
            gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return $"Aminal sound!";
    }

    private void ValidateInput(string input)
    {
        if (input == "")
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}");
        sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        sb.AppendLine($"{ProduceSound()}");

        return sb.ToString().TrimEnd(); 
    }

}

