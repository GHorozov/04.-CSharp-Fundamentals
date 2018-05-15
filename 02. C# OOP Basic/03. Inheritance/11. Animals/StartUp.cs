using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StartUp
{
    static void Main(string[] args)
    {
        string type;
        while (!(type = Console.ReadLine()).Equals("Beast!"))
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if(tokens.Length != 3)
                {
                    throw new ArgumentException("Invalid input!");
                }

                Animal animal = null;
                switch (type)
                {
                    case "Cat":
                        animal = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        break;
                        ;
                    case "Dog":
                        animal = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        break;
                    case "Frog":
                        animal = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        break;
                        ;
                    case "Kitten":
                        animal = new Kitten(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
                Console.WriteLine(animal);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}

