using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    private Manager manager;

    public Engine()
    {
        this.manager= new Manager();
    }

    public void Run()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var command = Console.ReadLine().Split(' ');

            try
            {
                switch (command[0])
                {
                    case "Create":
                        var name = command[2];

                        if (command[1] == "Pet")
                        {
                            var age = int.Parse(command[3]);
                            var kind = command[4];

                            manager.CreatePet(new Pet(name, age, kind));
                        }
                        else if (command[1] == "Clinic")
                        {
                            var room = int.Parse(command[3]);

                            manager.CreateClinic(new Clinic(name, room));
                        }
                        break;

                    case "Add":
                        var petName = command[1];
                        var clinicName = command[2];

                        Console.WriteLine(manager.AddPetToClinic(petName,clinicName));
                        break;

                    case "Release":
                        clinicName = command[1];

                        Console.WriteLine(manager.ReleasePet(clinicName));
                        break;

                    case "HasEmptyRooms":
                        clinicName = command[1];

                        Console.WriteLine(manager.HasEmptyRoom(clinicName));
                        break;
                    case "Print":
                        if (command.Length == 2)
                        {
                            clinicName = command[1];

                            Console.WriteLine(manager.PrintAll(clinicName));
                        }
                        else if (command.Length == 3)
                        {
                            clinicName = command[1];
                            var room = int.Parse(command[2]);

                            Console.WriteLine(manager.Print(clinicName, room));
                        }
                        break;

                    default:
                        throw new InvalidOperationException("Invalid Operation!");
                }
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
