using System;
using System.Collections.Generic;
using System.Text;

public class User
{
    private HashSet<Category> categories;

    public User(string name)
    {
        this.Name = name;
        this.categories = new HashSet<Category>();
    }

    public string Name { get; set; }
    public IReadOnlyCollection<Category> Categories => this.categories;

    public void AssignCategory(Category category)
    {
        this.categories.Add(category);
    }
}


