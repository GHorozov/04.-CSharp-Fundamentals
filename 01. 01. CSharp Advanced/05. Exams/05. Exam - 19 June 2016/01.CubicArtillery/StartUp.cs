namespace _01.CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var bunkers = new Queue<char>();
            var weapons = new Queue<int>();
            var freeCapacity = maxCapacity;

            string input;
            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var line = input
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var item in line)
                {
                    var num = 0;
                    if (!int.TryParse(item, out num))
                    {
                        bunkers.Enqueue(char.Parse(item));

                    }
                    else
                    {
                        int weaponCapacity = int.Parse(item);

                        bool weaponContained = false;
                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weaponCapacity)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                weaponContained = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = maxCapacity;
                        }

                        if (!weaponContained && bunkers.Count == 1)
                        {
                            if (maxCapacity >= weaponCapacity)
                            {
                                if (freeCapacity < weaponCapacity)
                                {
                                    while (freeCapacity < weaponCapacity)
                                    {
                                        int removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }

                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }
                }
            }
        }
    }
}
