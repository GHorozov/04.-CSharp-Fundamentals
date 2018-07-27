using System;
using System.Collections.Generic;
using System.Linq;

class Google
{
    static void Main(string[] args)
    {
        var people = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var lineParts = input
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var name = lineParts[0];
            var infoFor = lineParts[1];

            if(!people.Any(x => x.name == name))
            {
                var newPerson = new Person(name);
                AddPersonInfo(lineParts, infoFor, newPerson);
                people.Add(newPerson);
            }
            else
            {
                var currentPaerson = people.FirstOrDefault(x => x.name == name);
                AddPersonInfo(lineParts, infoFor, currentPaerson);
            }
        }

        var theName = Console.ReadLine();
        Console.WriteLine(people.FirstOrDefault(x => x.name == theName));
    }

    private static void AddPersonInfo(string[] lineParts, string infoFor, Person newPerson)
    {
        switch (infoFor)
        {
            case "company":
                var companyName = lineParts[2];
                var department = lineParts[3];
                var salary = decimal.Parse(lineParts[4]);
                var newCompany = new Company(companyName, department, salary);
                newPerson.AddCompany(newCompany);
                break;
            case "pokemon":
                var pokemonName = lineParts[2];
                var pokemonType = lineParts[3];
                var newPokemon = new Pokemon(pokemonName, pokemonType);
                newPerson.AddPokemon(newPokemon);
                break;
            case "parents":
                var parentName = lineParts[2];
                var parentBirthday = lineParts[3];
                var newParent = new Parent(parentName, parentBirthday);
                newPerson.AddParent(newParent);
                break;
            case "children":
                var childrenName = lineParts[2];
                var childrenBirthday = lineParts[3];
                var newChild = new Children(childrenName, childrenBirthday);
                newPerson.AddChildren(newChild);
                break;
            case "car":
                var carModel = lineParts[2];
                var carSpeed = lineParts[3];
                var newCar = new Car(carModel, carSpeed);
                newPerson.AddCar(newCar);
                break;
            default:
                break;
        }
    }
}
