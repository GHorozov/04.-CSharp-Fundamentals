using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Children> childrens;
    private Car car;

    public Person(string name)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.childrens = new List<Children>();
    }

    public void AddCompany(Company newCompany)
    {
        this.company = newCompany;
    }

    public void AddCar(Car newCar)
    {
        this.car = newCar;
    }

    public void AddPokemon(Pokemon newPokemon)
    {
        pokemons.Add(newPokemon);
    }
    public void AddParent(Parent newParent)
    {
        parents.Add(newParent);
    }
    public void AddChildren(Children newChildren)
    {
        childrens.Add(newChildren);
    }
        

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.name);
        sb.AppendLine($"Company:");
        if (this.company != null)
        {
            sb.AppendLine($"{this.company}");
        }

        sb.AppendLine($"Car:");
        if (this.car != null)
        {
            sb.AppendLine($"{this.car}");
        }

        sb.AppendLine($"Pokemon:");
        if (this.pokemons.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.pokemons));
        }

        sb.AppendLine($"Parents:");
        if (this.parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.parents));
        }

        sb.AppendLine($"Children:");
        if (this.childrens.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.childrens));
        }

        return sb.ToString().TrimEnd(); 
    }
}