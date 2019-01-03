public class Private : Soldier, IPrivate
{
    public Private(int id, string firstName, string lastName, double salary)
        :base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary { get; set; }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {this.Id} Salary: {Salary:f2}";
    }
}

