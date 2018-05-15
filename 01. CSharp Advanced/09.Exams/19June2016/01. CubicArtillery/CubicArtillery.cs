using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicArtillery
{
    class CubicArtillery
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            string input; 

            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            var leftCapacity = maxCapacity;

            while((input = Console.ReadLine()) != "Bunker Revision")
            {
                var inputLine = input.Split(' ');

                foreach (var entry in inputLine)
                {
                    var currentWeapon = 0;
                    bool isDigit = int.TryParse(entry, out currentWeapon);

                    if (!isDigit)
                    {
                        bunkers.Enqueue(entry);
                    }
                    else
                    {
                        var isSaved = false;
                        while (bunkers.Count > 1) //Bunkers are more than one.
                        {
                            if(leftCapacity >= currentWeapon) //If left capacity has space for current weapon.
                            {
                                weapons.Enqueue(currentWeapon); //Add current weapon.
                                leftCapacity -= currentWeapon; //Srink left capacity.
                                isSaved = true; //If currentWeapon is saved in weapons == true
                                break;
                            }

                            if(weapons.Count == 0) //If there ane no weapons in bunker
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                            }
                            else //If there are weapons in bunker
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                            }

                            weapons.Clear();
                            leftCapacity = maxCapacity;
                        }

                        if (!isSaved)
                        {
                            if(currentWeapon <= maxCapacity)
                            {
                                while (leftCapacity < currentWeapon) //Check if cerrentWeapon can fit in left capacity. While can not fit.
                                {
                                    leftCapacity += weapons.Dequeue(); //revomed space from weapons increace space in leftCapacity
                                }

                                weapons.Enqueue(currentWeapon); //add currentWeapon after space is open from weapons queue
                                leftCapacity -= currentWeapon; //left capacity decrease with size of currentWeapon
                            }
                        }
                    }
                   
                }

                
            }
        }
    }
}
