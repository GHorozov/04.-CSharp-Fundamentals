using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Category
{
    private string name;
    private HashSet<User> users;
    private HashSet<Category> categories;

    public Category(string name)
    {
        this.Name = name;
        this.users = new HashSet<User>();
        this.categories = new HashSet<Category>();
    }

    public string Name { get; set; }
    public IReadOnlyCollection<User> Users => this.users.ToList().AsReadOnly();
    public IReadOnlyCollection<Category> Categories => this.categories.ToList().AsReadOnly();

    public void AssignToCategory(Category category)
    {
        this.categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        this.categories.Remove(category);
    }

    public void AssignToUsers(User user)
    {
        this.users.Add(user);
    }

    public void AssignToParentCategory(Category parent)
    {
        parent.categories.Add(this);
    }
}

