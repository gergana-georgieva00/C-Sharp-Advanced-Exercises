using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] spl = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = spl[0];
                string pokemonName = spl[1];
                string pokemonElement = spl[2];
                int pokemonHealth = int.Parse(spl[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(t => t.Name == trainerName))
                {
                    Trainer currTrainer = trainers.Find(t => t.Name == trainerName);
                    currTrainer.Pokemons.Add(pokemon);
                    continue;
                }
                
                Trainer trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }

            string command1;
            while ((command1 = Console.ReadLine()) != "End")
            {
                if (command1.Contains("Fire"))
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Fire"))
                        {
                            trainer.NumberOfBadges++;
                        }
                        else
                        {
                            trainer.Pokemons.ForEach(p => p.Health -= 10);
                            trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                        }
                    }

                }
                else if (command1.Contains("Water"))
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Water"))
                        {
                            trainer.NumberOfBadges++;
                        }
                        else
                        {
                            trainer.Pokemons.ForEach(p => p.Health -= 10);
                            trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                        }
                    }
                }
                else
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Electricity"))
                        {
                            trainer.NumberOfBadges++;
                        }
                        else
                        {
                            trainer.Pokemons.ForEach(p => p.Health -= 10);
                            trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
