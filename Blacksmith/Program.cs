using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> swords = new Dictionary<string, int>();

            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);

            int count = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int sum = steel.Peek() + carbon.Peek();

                if (sum == 70 || sum == 80 || sum == 90 || sum == 110 || sum == 150)
                {
                    switch (sum)
                    {
                        case 70:
                            swords["Gladius"]++;
                            break;
                        case 80:
                            swords["Shamshir"]++;
                            break;
                        case 90:
                            swords["Katana"]++;
                            break;
                        case 110:
                            swords["Sabre"]++;
                            break;
                        case 150:
                            swords["Broadsword"]++;
                            break;
                    }

                    count++;

                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();

                    int currCarbon = carbon.Pop() + 5;
                    carbon.Push(currCarbon);
                }
            }

            if (count > 0)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (count > 0)
            {
                foreach (var sword in swords.OrderBy(s => s.Key))
                {
                    if (sword.Value > 0)
                    {
                        Console.WriteLine($"{sword.Key}: {sword.Value}");
                    }
                }
            }
        }
    }
}
