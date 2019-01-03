using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Repository
{
    private HashSet<User> users;
    private HashSet<Category> categories;

    public Repository()
    {
        this.users = new HashSet<User>();
        this.categories = new HashSet<Category>();
    }

    public IReadOnlyCollection<Category> Categories => this.categories;
    public IReadOnlyCollection<User> Users => this.users;

    public void AddUser(User user)
    {
        this.users.Add(user);
    }

    public void AddCategory(Category category)
    {
        if (this.categories.Any(c => c.Name == category.Name))
        {
            throw new InvalidOperationException();
        }

        this.categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        if (!this.categories.Any(c => c.Name == category.Name))
        {
            throw new InvalidOperationException();
        }

        foreach (var cat in this.categories)
        {
            if (cat.Categories.Contains(category))
            {
                cat.RemoveCategory(category);
            }
        }

        if (category.Categories.Any())
        {
            foreach (var subCategory in category.Categories)
            {
                foreach (var user in category.Users)
                {
                    subCategory.AssignToUsers(user);
                    user.AssignCategory(subCategory);
                }
            }
        }

        var targetCategory = this.categories.FirstOrDefault(x => x.Name == category.Name);
        this.categories.Remove(targetCategory);
    }

    public void AddChildToParentCategory(Category parent, Category child)
    {
        child = this.categories.SingleOrDefault(c => c.Name == child.Name);
        parent = this.categories.SingleOrDefault(c => c.Name == parent.Name);

        if (child == null || parent == null)
        {
            throw new InvalidOperationException();
        }

        foreach (var category in this.categories)
        {
            if (category.Categories.Contains(child))
            {
                category.RemoveCategory(child);
            }
        }

        child.AssignToParentCategory(parent);
    }

    public void AddUserToCategory(Category category, User user)
    {
        category = this.categories.SingleOrDefault(c => c.Name == category.Name);

        if (category == null || !this.users.Contains(user))
        {
            throw new InvalidOperationException();
        }

        category.AssignToUsers(user);
        user.AssignCategory(category);
    }
}

