namespace _01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var locks = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var inteligenceValue = int.Parse(Console.ReadLine());

            var stackBullets = new Stack<int>(bullets);
            var queueLocks = new Queue<int>(locks);

            var isNotOver = true;
            var totalBulletsCost = 0;
            while (isNotOver)
            {
                for (int i = 0; i < gunBarrelSize; i++)
                {
                    if (stackBullets.Count <= 0 || queueLocks.Count <= 0)
                    {
                        isNotOver = false;
                        break;
                    }

                    var currentBullet = stackBullets.Pop();
                    var currentLock = queueLocks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        queueLocks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    totalBulletsCost += bulletPrice;
                }

                if(stackBullets.Count > 0 && isNotOver == true)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if(queueLocks.Count <= 0)
            {
                var moneyEarned = inteligenceValue - totalBulletsCost;
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
        }
    }
}
