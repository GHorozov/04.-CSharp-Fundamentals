using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    protected string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if(value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");

        return base.ToString() + sb.ToString();
    }
}

