using System;

public class AnimalFactory
{
    private Foodfactory foodfactory = new Foodfactory();

    public Animal GetAnimal(string[] input)
    {
        var animalType = input[0];
        var name = input[1];

        Animal animal = null;
        switch (animalType)
        {
            case "Hen":
                var weight = double.Parse(input[2]);
                var wingSize = double.Parse(input[3]);
                animal = new Hen(name, weight, wingSize);
                break;
            case "Owl":
                weight = double.Parse(input[2]);
                wingSize = double.Parse(input[3]);
                animal = new Owl(name, weight, wingSize);
                break;
            case "Mouse":
                weight = double.Parse(input[2]);
                var livingRegion = input[3];
                animal = new Mouse(name, weight, livingRegion);
                break;
            case "Cat":
                weight = double.Parse(input[2]);
                livingRegion = input[3];
                var breed = input[4];
                animal = new Cat(name, weight, livingRegion, breed);
                break;
            case "Dog":
                weight = double.Parse(input[2]);
                livingRegion = input[3];
                animal = new Dog(name, weight, livingRegion);
                break;
            case "Tiger":
                weight = double.Parse(input[2]);
                livingRegion = input[3];
                breed = input[4];
                animal = new Tiger(name, weight, livingRegion, breed);
                break;
          
            default:
                break;
        }

        return animal;
    }
}