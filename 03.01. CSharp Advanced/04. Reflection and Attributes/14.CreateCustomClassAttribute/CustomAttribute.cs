using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CustomAttribute :Attribute
{
    public CustomAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
        this.Reviewers = new List<string>(reviewers);
    }

    public string Author { get; set; }
    public int Revision { get; set; }
    public string Description { get; set; }
    public List<string> Reviewers  { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Revision: { this.Revision.ToString()}");
        sb.AppendLine($"Class description: {this.Description}");
        sb.AppendLine($"Reviewers: {string.Join(", ", this.Reviewers)}");

        return sb.ToString().TrimEnd(); 
    }
}

