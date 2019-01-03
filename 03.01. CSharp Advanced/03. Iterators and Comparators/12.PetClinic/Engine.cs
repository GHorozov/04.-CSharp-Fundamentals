using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private Manager manager;

    public Engine()
    {
        this.manager = new Manager();
    }

    public void Run()
    {
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var command = Console.ReadLine().Split();

            try
            {
                switch (command[0])
                {
                    case "Create":
                        var clinicOrPet = command[1];
                        if (clinicOrPet == "Clinic")
                        {
                            manager.CreateClinic(new Clinic(command[2],int.Parse(command[3])));
                        }
                        else if (clinicOrPet == "Pet")
                        {
                            var newPet = new Pet(command[2], int.Parse(command[3]), command[4]);
                            manager.CreatePet(newPet);
                        }
                        break;
                    case "Add":
                        var petName = command[1];
                        var clinicName = command[2];
                        Console.WriteLine(manager.AddPet(petName, clinicName));
                        break;
                    case "Release":
                        Console.WriteLine(manager.Release(command[1]));
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(manager.HasEmptyRooms(command[1]));
                        break;
                    case "Print":
                        if (command.Length == 2)
                        {
                            manager.PrintAll(command[1]);
                        }
                        else
                        {
                            manager.Print(command[1], int.Parse(command[2]));
                        }
                        break;
                    default:
                        throw new InvalidOperationException("Invalid command input!Try againg!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

