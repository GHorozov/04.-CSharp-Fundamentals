using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        Stack<string> stackCollection = new Stack<string>();
        var input = Console.ReadLine();

        try
        {
            while (input != "END")
            {
                var command = input.Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToList();

                switch (command[0])
                {
                    case "Push":
                        stackCollection.Push(command.Skip(1).ToList());
                        break;
                    case "Pop":
                        stackCollection.Pop();
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(stackCollection.Print());
            Console.WriteLine(stackCollection.Print());
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        
    }
}

