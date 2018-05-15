﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Persons
{
    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons= new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArg = Console.ReadLine().Split(' ');
            var person = new Person(cmdArg[0], cmdArg[1], int.Parse(cmdArg[2]));

            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName)
            .ThenBy(p => p.Age)
            .ToList()
            .ForEach(p => Console.WriteLine(p.ToString()));
    }
}
