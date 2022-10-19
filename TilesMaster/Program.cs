using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> white = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> grey = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> tiles = new Dictionary<string, int>();
            tiles.Add("Sink", 0);
            tiles.Add("Oven", 0);
            tiles.Add("Countertop", 0);
            tiles.Add("Wall", 0);
            tiles.Add("Floor", 0);

            while (white.Count > 0 && grey.Count > 0)
            {
                if (white.Peek() == grey.Peek())
                {
                    int sum = white.Pop() + grey.Dequeue();

                    switch (sum)
                    {
                        case 40:
                            tiles["Sink"]++;
                            break;
                        case 50:
                            tiles["Oven"]++;
                            break;
                        case 60:
                            tiles["Countertop"]++;
                            break;
                        case 70:
                            tiles["Wall"]++;
                            break;
                        default:
                            tiles["Floor"]++;
                            break;
                    }
                }
                else
                {
                    int newWhite = white.Pop() / 2;
                    white.Push(newWhite);

                    grey.Enqueue(grey.Dequeue());
                }
            }

            if (white.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }

            if (grey.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }

            //"Countertop: {amount}"
            // "Floor: {amount}"
            //"Oven: {amount}"
            //"Sink: {amount}"
            //"Wall: {amount}"

            //The locations must be ordered descending by number (count of new tiles per location)
            //and then sorted ascending alphabetically.

            foreach (var type in tiles.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                if (type.Value > 0)
                {
                    Console.WriteLine($"{type.Key}: {type.Value}");
                }
            }

        }
    }
}
