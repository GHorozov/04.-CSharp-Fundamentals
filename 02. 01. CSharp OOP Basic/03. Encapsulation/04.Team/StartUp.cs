﻿namespace _04.TeamTask
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));

                    persons.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
           
            Team team = new Team("SoftUni");
            foreach (var p in persons)
            {
                team.AddPlayer(p);
            }

            Console.WriteLine(team.ToString());
        }
    }
}
