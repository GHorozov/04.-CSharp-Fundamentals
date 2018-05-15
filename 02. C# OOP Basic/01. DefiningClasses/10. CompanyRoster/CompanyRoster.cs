using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompanyRoster
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var employeesList = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var lineParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = lineParts[0];
            var salary= decimal.Parse(lineParts[1]);
            var position = lineParts[2];
            var department = lineParts[3];

            var currentEmployee = new Employee(name, salary, position, department);

            if (lineParts.Length > 4)
            {
                if (lineParts[4].Contains("@"))
                {
                    var email = lineParts[4];
                    currentEmployee.Email = email;
                }
                else
                {
                    var age = int.Parse(lineParts[4]);
                    currentEmployee.Age = age;
                }
                
            }

            if(lineParts.Length > 5)
            {
                var age = int.Parse(lineParts[5]);
                currentEmployee.Age = age;
            }

            employeesList.Add(currentEmployee);
        }


        //var result = employeesList
        //     .GroupBy(e => e.Department) //Group by department
        //     .Select(e => new  //Create new anonymus object
        //     {
        //         DepartmentName = e.Key, //Name of department
        //         AverageSalary = e.Average(emp => emp.Salary), //Average Selary for all departments
        //         Emp = e.OrderByDescending(emp => emp.Salary) //Order by descending employees by Salary size
        //     })
        //     .FirstOrDefault(); //Take only first result that is equal to my search

        var result = employeesList
            .GroupBy(e => e.Department)
            .OrderByDescending(g => g.Select(e => e.Salary).Sum())
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Key}");

        foreach (var employee in result.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}

