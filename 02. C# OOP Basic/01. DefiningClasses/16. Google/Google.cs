using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Google
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var people = new List<Person>();

        while (input != "End")
        {
            var lineParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currentName = lineParts[0];
            var currentCategory = lineParts[1];

            var currentPerson = people.Where(p => p.Name == currentName).FirstOrDefault();

            if (currentPerson == null) //If there is not person with same name
            {
                currentPerson = new Person(currentName); //Create new Person with currentName
                people.Add(currentPerson);    //Add this person to list of people
            }

           
            switch (currentCategory) //Add only new data to people list
            {
                case "company":
                    var companyName = lineParts[2] + " " + lineParts[3];
                    var selary = decimal.Parse(lineParts[4]);
                    currentPerson.AddCompany(new Company(companyName, selary));
                    break;
                case "pokemon":
                    var pokemonName = lineParts[2] + " " + lineParts[3];
                    currentPerson.AddPokemon(new Pokemon(pokemonName));
                    break;
                case "parents":
                    var parentsInfo = lineParts[2] + " " + lineParts[3];
                    currentPerson.AddParents(new Parents(parentsInfo));
                    break;
                case "children":
                    var childrenInfo = lineParts[2] + " " + lineParts[3];
                    currentPerson.AddChildren(new Children(childrenInfo));
                    break;
                case "car":
                    var carInfo = lineParts[2] + " " + lineParts[3];
                    currentPerson.AddCar(new Car(carInfo));
                    break;
            }

            input = Console.ReadLine();
        }

        var nameToPrint = Console.ReadLine();
        var person = people.FirstOrDefault(p => p.Name == nameToPrint);

        if (person != null)
        {
            Console.Write(person.ToString());
        }
    }
}

