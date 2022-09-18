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
            int currBulletCount = 0;

            while (stackBullets.Count > 0 && queueLocks.Count > 0)
            {
                if (stackBullets.Peek() <= queueLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                stackBullets.Pop();
                bulletsCount++;
                currBulletCount++;

                if (stackBullets.Count > 0 && currBulletCount == sizeGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                    currBulletCount = 0;
                }
            }

            if (stackBullets.Count >= 0 && queueLocks.Count == 0)
            {
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueIntelligence - (bulletsCount * priceBullet)}");
                
                return;
            }

            Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
        }
    }
}
