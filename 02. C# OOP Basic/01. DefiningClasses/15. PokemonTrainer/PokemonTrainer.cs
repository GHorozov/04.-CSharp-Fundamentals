using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PokemonTrainer
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var trainersList = new List<Trainer>();
        while(input != "Tournament")
        {
            var lineInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = lineInfo[0];
            var pokemonName = lineInfo[1];
            var pokemonElement = lineInfo[2];
            var pokemonHealth = int.Parse(lineInfo[3]);

            var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            var currentTrainer = trainersList.Where(t => t.Name == trainerName).FirstOrDefault();//Checks if there is trainer with same name as trainerName
           
           if(currentTrainer == null) //If there isn't
            {
                currentTrainer = new Trainer(trainerName); //make new object Trainer and add trainerName
                currentTrainer.Pokemon.Add(newPokemon); //To current trainer select pokemon and Add to pokemon newPokemon(with all data)
                trainersList.Add(currentTrainer); //Add to list
            }
            else //If there is add only to pokemon newPokemon data
            {
                currentTrainer.Pokemon.Add(newPokemon);
            }


            input = Console.ReadLine();
        }

        var elementsInfo = Console.ReadLine();

        while(elementsInfo != "End")
        {
            foreach (var trainer in trainersList)
            {
                if(trainer.Pokemon.Where(p=>p.Element == elementsInfo).FirstOrDefault() == null) //Searched element is not in trainer
                {
                    foreach (var pokemon in trainer.Pokemon)
                    {
                        pokemon.ReduceHealth();
                    }

                    trainer.ClearDeadPokemons();
                }
                else
                {
                    trainer.AddBadges();
                }

            }
            elementsInfo = Console.ReadLine();
        }

        foreach (var trainer in trainersList.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
        }
    }
}

