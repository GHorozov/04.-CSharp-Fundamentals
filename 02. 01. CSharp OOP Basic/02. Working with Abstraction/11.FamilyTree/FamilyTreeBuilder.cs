using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    public List<Person> FamilyTree { get; set; }
    public Person MainPerson { get; set; }

    public FamilyTreeBuilder(string mainPersonInput)
    {
        this.FamilyTree = new List<Person>();
        this.MainPerson = Person.CreatePerson(mainPersonInput);
        FamilyTree.Add(MainPerson);
    }

    public void ParseInput(string command)
    {
        string[] tokens = command.Split(" - ");
        if (tokens.Length > 1)
        {
            SetParentChildRelation(tokens);
        }
        else
        {
            tokens = SetFullInfo(tokens);
        }
    }
    public void PrintPersonTree()
    {
        Console.WriteLine(this.MainPerson);
        Console.WriteLine("Parents:");
        foreach (var p in this.MainPerson.Parents)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("Children:");
        foreach (var c in this.MainPerson.Children)
        {
            Console.WriteLine(c);
        }
    }

    public string[] SetFullInfo(string[] tokens)
    {
        tokens = tokens[0].Split();
        string name = $"{tokens[0]} {tokens[1]}";
        string birthday = tokens[2];

        var person = this.FamilyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            this.FamilyTree.Add(person);
        }
        person.Name = name;
        person.Birthday = birthday;

        CheckForDuplicates(person);

        return tokens;
    }

    public void CheckForDuplicates(Person person)
    {
        var name = person.Name;
        var birthday = person.Birthday;

        Person duplicate = this.FamilyTree
            .Where(x => x.Birthday == birthday || x.Name == name)
            .Skip(1)
            .FirstOrDefault();

        if (duplicate != null)
        {
            RemoveDuplicate(person, duplicate);
        }
    }

    public void RemoveDuplicate(Person person, Person duplicate)
    {
        this.FamilyTree.Remove(duplicate);
        person.Parents.AddRange(duplicate.Parents);
        person.Parents = person.Parents.Distinct().ToList();

        foreach (var parent in duplicate.Parents)
        {
            ReplaceDuplicate(person, duplicate, parent.Children);
        }

        person.Children.AddRange(duplicate.Children);
        person.Children = person.Children.Distinct().ToList();

        foreach (var child in duplicate.Children)
        {
            ReplaceDuplicate(person, duplicate, child.Parents);
        }
    }

    public void ReplaceDuplicate(Person original, Person duplicate, List<Person> collection)
    {
        int duplicateIndex = collection.IndexOf(duplicate);
        if (duplicateIndex > -1)
        {
            collection[duplicateIndex] = original;
        }
        else
        {
            collection.Add(original);
        }
    }

    public void SetChild(Person parent, string childInput)
    {
        var child = this.FamilyTree
            .FirstOrDefault(x => x.Name == childInput || x.Birthday == childInput);

        if (child == null)
        {
            child = Person.CreatePerson(childInput);
            this.FamilyTree.Add(child);
        }

        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    public void SetParentChildRelation(string[] tokens)
    {
        string parentInput = tokens[0];
        string childInput = tokens[1];

        Person currentPerson = this.FamilyTree.FirstOrDefault(p => p.Birthday == parentInput || p.Name == parentInput);


        if (currentPerson == null)
        {
            currentPerson = Person.CreatePerson(parentInput);

            this.FamilyTree.Add(currentPerson);
        }

        SetChild(currentPerson, childInput);
    }
}

