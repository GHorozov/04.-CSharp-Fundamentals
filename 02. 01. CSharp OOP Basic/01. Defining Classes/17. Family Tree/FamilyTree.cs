using System;
using System.Collections.Generic;
using System.Linq;

class FamilyTree
{
    static void Main(string[] args)
    {
        var personNameBirthday = Console.ReadLine();
        var people = new List<Person>();
        var parents = new List<string>();
        var children = new List<string>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var lineParts = input.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            if (lineParts.Length > 1)
            {
                parents.Add(lineParts[0]);
                children.Add(lineParts[1]);
            }
            else
            {
                var lineArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{lineArgs[0]} {lineArgs[1]}";
                var birthday = lineArgs[2];
                people.Add(new Person(name, birthday));
            }
        }

        SolveRelations(people, parents, children);

        PrintResult(personNameBirthday, people);
    }

    private static void SolveRelations(List<Person> people, List<string> parents, List<string> children)
    {
        for (int i = 0; i < parents.Count; i++)
        {
            var parentInfo = parents[i];
            var childInfo = children[i];

            Person currentParent = null;
            Person currentChild = null;

            if (parentInfo.Contains("/") && people.Any(x => x.Birthday == parentInfo))
            {
                currentParent = people.FirstOrDefault(x => x.Birthday == parentInfo);
               
                if (childInfo.Contains("/"))
                {
                    currentChild = people.FirstOrDefault(x => x.Birthday == childInfo);
                }
                else
                {
                    currentChild = people.FirstOrDefault(x => x.Name == childInfo);
                }
            }
            else
            {
                currentParent = people.FirstOrDefault(x => x.Name == parentInfo);
                if (childInfo.Contains("/"))
                {
                    currentChild = people.FirstOrDefault(x => x.Birthday == childInfo);
                }
                else
                {
                    currentChild = people.FirstOrDefault(x => x.Name == childInfo);
                }
            }

            currentParent.AddChildren(currentChild);
            currentChild.AddParent(currentParent);
        }
    }

    private static void PrintResult(string personNameBirthday, List<Person> people)
    {
        if (personNameBirthday.Contains("/"))
        {
            Console.WriteLine(people.FirstOrDefault(x => x.Birthday == personNameBirthday).ToString());
        }
        else
        {
            Console.WriteLine(people.FirstOrDefault(x => x.Name == personNameBirthday).ToString());
        }
    }
}

