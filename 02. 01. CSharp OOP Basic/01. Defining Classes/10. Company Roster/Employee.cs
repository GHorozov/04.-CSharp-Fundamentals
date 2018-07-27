public class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email = "n/a";
    public int age = -1;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email):this(name, salary, position, department)
    {
        this.email = email;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age): this(name, salary, position, department, email)
    {
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
    {
        this.age = age;
    }
}

