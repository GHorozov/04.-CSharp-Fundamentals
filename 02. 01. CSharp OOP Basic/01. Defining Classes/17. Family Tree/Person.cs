using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private List<Person> parents = new List<Person>();
    private List<Person> children = new List<Person>();

    public Person()
    {
      
    }

    public Person(string name, string birthday) 
    {
        this.Name = name;
        this.Birthday = birthday;
    }


    public string Name { get; set; }
    public string Birthday { get; set; }

    public void AddParent(Person newParent)
    {
        this.parents.Add(newParent);
    }

    public void AddChildren(Person newChild)
    {
        this.children.Add(newChild);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.Birthday}");
        sb.AppendLine("Parents:");
        if(this.parents.Count > 0)
        {
            foreach (var parent in parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
        }
        sb.AppendLine("Children:");
        if (this.children.Count > 0)
        {
            foreach (var child in children)
            {
                sb.AppendLine($"{child.Name} {child.Birthday}");
            }
        }

        return sb.ToString().TrimEnd(); 
    }
}