namespace AnimalCentre
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    var result = string.Empty;
                    switch (command)
                    {
                        case "RegisterAnimal":
                            result = animalCentre.RegisterAnimal(args[0], args[1], int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4]));
                            break;
                        case "Chip":
                            result = animalCentre.Chip(args[0], int.Parse(args[1]));
                            break;
                        case "Vaccinate":
                            result = animalCentre.Vaccinate(args[0], int.Parse(args[1]));
                            break;
                        case "Fitness":
                            result = animalCentre.Fitness(args[0], int.Parse(args[1]));
                            break;
                        case "Play":
                            result = animalCentre.Play(args[0], int.Parse(args[1]));
                            break;
                        case "DentalCare":
                            result = animalCentre.DentalCare(args[0], int.Parse(args[1]));
                            break;
                        case "NailTrim":
                            result = animalCentre.NailTrim(args[0], int.Parse(args[1]));
                            break;
                        case "Adopt":
                            result = animalCentre.Adopt(args[0], args[1]);
                            break;
                        case "History":
                            result = animalCentre.History(args[0]);
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"ArgumentException: {e.Message}");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
            }

            var sb = new StringBuilder();
            foreach (var owner in this.animalCentre.AdoptedAnimals.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.Append($"    - Adopted animals: ");
                sb.AppendLine(string.Join(" ", owner.Value));
            }

            if(sb.Length > 0)
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
