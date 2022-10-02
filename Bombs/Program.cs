using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bombCasingsArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(bombEffectsArr);
            Stack<int> bombCasings = new Stack<int>(bombCasingsArr);

            int daturaBomb = 40;
            int cherryBomb = 60;
            int smokeDecoyBomb = 120;

            bool filledPouch = false;

            Dictionary<string, int> bombPouch = new Dictionary<string, int>();

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (bombPouch.ContainsKey("cherry bomb") && bombPouch["cherry bomb"] >= 3
                    && bombPouch.ContainsKey("datura bomb") && bombPouch["datura bomb"] >= 3 
                    && bombPouch.ContainsKey("smoke deco bomb") && bombPouch["smoke deco bomb"] >= 3)
                {
                    filledPouch = true;
                    break;
                }

                int currSum = bombEffects.Peek() + bombCasings.Peek();

                if (currSum == daturaBomb || currSum == cherryBomb || currSum == smokeDecoyBomb)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();

                    if (currSum == daturaBomb)
                    {
                        if (!bombPouch.ContainsKey("datura bomb"))
                        {
                            bombPouch.Add("datura bomb", 1);
                        }
                        else
                        {
                            bombPouch["datura bomb"]++;
                        }
                    }
                    else if (currSum == cherryBomb)
                    {
                        if (!bombPouch.ContainsKey("cherry bomb"))
                        {
                            bombPouch.Add("cherry bomb", 1);
                        }
                        else
                        {
                            bombPouch["cherry bomb"]++;
                        }
                    }
                    else
                    {
                        if (!bombPouch.ContainsKey("smoke deco bomb"))
                        {
                            bombPouch.Add("smoke deco bomb", 1);
                        }
                        else
                        {
                            bombPouch["smoke deco bomb"]++;
                        }
                    }
                }
                else
                {
                    int currValue = bombCasings.Pop() - 5;
                    bombCasings.Push(currValue);
                }
            }

            if (filledPouch == true)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            if (bombPouch.ContainsKey("cherry bomb"))
            {
                Console.WriteLine($"Cherry Bombs: {bombPouch["cherry bomb"]}");
            }
            else
            {
                Console.WriteLine($"Cherry Bombs: 0");
            }

            if (bombPouch.ContainsKey("datura bomb"))
            {
                Console.WriteLine($"Datura Bombs: {bombPouch["datura bomb"]}");
            }
            else
            {
                Console.WriteLine($"Datura Bombs: 0");
            }

            if (bombPouch.ContainsKey("smoke deco bomb"))
            {
                Console.WriteLine($"Smoke Decoy Bombs: {bombPouch["smoke deco bomb"]}");
            }
            else
            {
                Console.WriteLine($"Smoke Decoy Bombs: 0");
            }
        }
    }
}
