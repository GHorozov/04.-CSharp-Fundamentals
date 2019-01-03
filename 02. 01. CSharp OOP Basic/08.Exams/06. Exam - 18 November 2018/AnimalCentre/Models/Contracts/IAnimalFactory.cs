namespace AnimalCentre.Models.Contracts
{
    using global::AnimalCentre.Models.Animals;

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string animalType, string name, int energy, int happiness, int procedureTime);
    }
}
