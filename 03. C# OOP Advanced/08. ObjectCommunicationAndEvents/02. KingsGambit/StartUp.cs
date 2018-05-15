using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StartUp
{
    static void Main(string[] args)
    {
        List<Soldier> army = new List<Soldier>();
        King king = new King(Console.ReadLine());


        string[] royalGuards = Console.ReadLine().Split(' ');
        foreach (var royalGuard in royalGuards)
        {
            RoyalGuard guard = new RoyalGuard(royalGuard);
            army.Add(guard);

            king.UnderAttack += guard.KingUnderAttack;
        }


        string[] footsmans = Console.ReadLine().Split(' ');
        foreach (var footsman in footsmans)
        {
            Footman newFoodsman = new Footman(footsman);
            army.Add(newFoodsman);

            king.UnderAttack += newFoodsman.KingUnderAttack;
        }


        var command = Console.ReadLine().Split(' ');

        while (command[0] != "End")
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
            }

            command = Console.ReadLine().Split(' ');
        }
    }
}
