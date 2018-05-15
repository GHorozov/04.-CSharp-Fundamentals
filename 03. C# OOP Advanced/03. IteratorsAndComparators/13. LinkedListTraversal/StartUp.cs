using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    public static void Main(string[] args)
    {
        LinkedList<int> listLinked = new LinkedList<int>();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "Add":
                    listLinked.Add(int.Parse(command[1]));
                    break;

                case "Remove":
                    listLinked.Remove(int.Parse(command[1]));
                    break;
            }
        }

        Console.WriteLine(listLinked.Count());
        Console.WriteLine(string.Join(" ", listLinked));
    }
}

