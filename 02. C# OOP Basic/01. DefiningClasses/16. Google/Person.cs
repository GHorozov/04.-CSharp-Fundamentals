using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemon;
    private List<Parents> parents;
    private List<Children> children;
    private Car car;

    public Person(string name)
    {
        this.name = name;
        this.pokemon = new List<Pokemon>();
        this.parents = new List<Parents>();
        this.children = new List<Children>();
    }

    public string Name
    {
        get { return this.name; }
    }

    public void AddCompany(Company company)
    {
        this.company = company;
    }

    public void AddCar(Car car)
    {
        this.car = car;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemon.Add(pokemon);
    }
    public void AddParents(Parents parents)
    {
        this.parents.Add(parents);
    }
    public void AddChildren(Children children)
    {
        this.children.Add(children);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.name);

        sb.AppendLine("Company:");
        if (this.company != null)
        {
            sb.AppendLine($"{this.company.Name.ToString()} {this.company.Selery:f2}");
        }

        sb.AppendLine("Car:");
        if (this.car != null)
        {
            sb.AppendLine(this.car.Name.ToString());
        }

        sb.AppendLine("Pokemon:");
        if (this.pokemon.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.pokemon.Select(pok => pok.Name.ToString())));
        }

        sb.AppendLine("Parents:");
        if (this.parents.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.parents.Select(par => par.Name.ToString())));
        }

        sb.AppendLine("Children:");
        if (this.children.Count > 0)
        {
            sb.AppendLine(string.Join(Environment.NewLine, this.children.Select(c => c.Name.ToString())));
        }

        return sb.ToString();
    }
}


