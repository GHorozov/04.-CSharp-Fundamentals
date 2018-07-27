using System;
using System.Collections.Generic;
using System.Linq;

class PokemonTrainer
{
    static void Main(string[] args)
    {
        var trainers = new List<Trainer>();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            var lineParts = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = lineParts[0];
            var pokemonName = lineParts[1];
            var pokemonElement = lineParts[2];
            var pokemonHealth = int.Parse(lineParts[3]);

            var newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if(!trainers.Any(x => x.name == trainerName))
            {
                var newTrainer = new Trainer(trainerName);
                newTrainer.AddPokemon(newPokemon);
                trainers.Add(newTrainer);
            }
            else
            {
                trainers.FirstOrDefault(x => x.name == trainerName).AddPokemon(newPokemon);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var currentElement = command;

            foreach (var trainer in trainers)
            {
                if (trainer.CheckForPokemon(currentElement))
                {
                    trainer.AddBadge();
                }
                else
                {
                    trainer.DecreaseHealth();
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(x => x.badges)));
    }
}


