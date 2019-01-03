using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private Person[] collection;

    public Database()
    {
        this.Collection = new Person[5];
    }

    public Person[] Collection
    {
        get
        {
            return this.collection;
        }
        private set
        {
            this.collection = value;
        }
    }

    public void Add(Person person)
    {
        var PersonByUsername = this.Collection.Where(x => x != null).FirstOrDefault(x => x.Username == person.Username);
        var PersonById = this.Collection.Where(x => x != null).FirstOrDefault(x => x.Id == person.Id);
        if (PersonByUsername != null || PersonById != null)
        {
            throw new InvalidOperationException("Collection already contain person with same username or id.");
        }

        for (int i = 0; i < this.Collection.Length; i++)
        {
            if (this.Collection[i] == null)
            {
                this.Collection[i] = person;
                break;
            }
        }
    }

    public void Remove()
    {
        for (int i = this.Collection.Length - 1; i >= 0; i--)
        {
            if (this.Collection[i] != null)
            {
                this.Collection[i] = null;
                break;
            }
        }
    }

    public Person FindByUsername(string username)
    {
        if(!this.Collection.Where(x => x != null).Any(x => x.Username == username))
        {
            if (username == null)
            {
                throw new ArgumentException("Username name cannot be null.");
            }

            throw new InvalidOperationException("The are is not username with that name.");
        }

        var person = this.Collection.Where(x => x != null).FirstOrDefault(x => x.Username == username);

        return person;
    }

    public Person FindById(long id)
    {
        if (!this.Collection.Where(x => x != null).Any(x => x.Id == id))
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot add negative id.");
            }

            throw new InvalidOperationException("The are is not username with that id.");
        }

        var person = this.Collection.Where(x => x != null).FirstOrDefault(x => x.Id == id);

        return person;
    }
}

