using System;
using System.Collections.Generic;
using System.Linq;

class CompanyRoster
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var list = new List<Employee>();
        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var name = lineParts[0];
            var salary = decimal.Parse(lineParts[1]);
            var position = lineParts[2];
            var department = lineParts[3];

            if (lineParts.Length == 4)
            {
                list.Add(new Employee(name, salary, position, department));
            }
            else if (lineParts.Length == 5)
            {
                if (lineParts[4].Contains("@"))
                {
                    var email = lineParts[4];
                    list.Add(new Employee(name, salary, position, department, email));
                }
                else
                {
                    var age = int.Parse(lineParts[4]);
                    list.Add(new Employee(name, salary, position, department, age));
                }
            }
            else
            {
                var email = lineParts[4];
                var age = int.Parse(lineParts[5]);
                list.Add(new Employee(name, salary, position, department, email, age));
            }
        }

        var departments = list.GroupBy(x => x.department).ToList();

        var highestAverageSalary = 0.00m;
        var departmentWithHighestAverageSalary = string.Empty;
        foreach (var dep in departments)
        {
            var averageSalary = list.Where(x => x.department == dep.Key).Average(x => x.salary);

            if (averageSalary > highestAverageSalary)
            {
                highestAverageSalary = averageSalary;
                departmentWithHighestAverageSalary = dep.Key;
            }
        }

        Console.WriteLine($"Highest Average Salary: {departmentWithHighestAverageSalary}");
        foreach (var employee in list.Where(x => x.department == departmentWithHighestAverageSalary).OrderByDescending(x => x.salary))
        {
            Console.WriteLine($"{employee.name} {employee.salary:f2} {employee.email} {employee.age}");
        }
    }
}

