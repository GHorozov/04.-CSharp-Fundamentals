public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public string FirstName { get => this.firstName;}
    public string LastName { get => this.lastName; }
    public int Age { get => age; }
    public decimal Salary { get => this.salary; }

    public void IncreaseSalary(decimal percentage)
    {
        if(this.Age < 30)
        {
            percentage = percentage / 2;
            var bonus = (this.salary * percentage) / 100;
            this.salary = this.salary + bonus;
        }
        else
        {
            this.salary = this.salary + ((this.salary * percentage) / 100);
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}

