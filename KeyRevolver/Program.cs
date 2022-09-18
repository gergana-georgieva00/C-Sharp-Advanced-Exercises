using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);

            int bulletsCount = 0;

            while (stackBullets.Count > 0 && queueLocks.Count > 0)
            {
                for (int i = 0; i < sizeGunBarrel; i++)
                {
                    if (stackBullets.Peek() <= queueLocks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        queueLocks.Dequeue();
                        stackBullets.Pop();
                        bulletsCount++;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        stackBullets.Pop();
                        bulletsCount++;
                    }
                }

                if (stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (stackBullets.Count == 0 && queueLocks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
                return;
            }

            Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueIntelligence - (bulletsCount * priceBullet)}");
        }
    }
}
