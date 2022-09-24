using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> sideUser = new Dictionary<string, HashSet<string>>();
            Dictionary<string, string> userSide = new Dictionary<string, string>();

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] spl = command.Split(" | ");

                    string side = spl[0];
                    string user = spl[1];

                    if (!userSide.ContainsKey(user))
                    {
                        userSide.Add(user, side);

                        if (!sideUser.ContainsKey(side))
                        {
                            sideUser.Add(side, new HashSet<string>());
                        }
                        
                        sideUser[side].Add(user);
                    }
                }
                else
                {
                    string[] spl = command.Split(" -> ");
                    
                    string user = spl[0];
                    string side = spl[1];

                    if (userSide.ContainsKey(user))
                    {
                        if (!sideUser.ContainsKey(side))
                        {
                            sideUser.Add(side, new HashSet<string>());
                        }

                        foreach (var currSet in sideUser)
                        {
                            if (currSet.Value.Contains(user))
                            {
                                currSet.Value.Remove(user);
                            }
                        }

                        sideUser[side].Add(user);
                        userSide[user] = side;
                    }
                    else
                    {
                        userSide.Add(user, side);

                        if (!sideUser.ContainsKey(side))
                        {
                            sideUser.Add(side, new HashSet<string>());
                        }

                        sideUser[side].Add(user);
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            foreach (var kvp in sideUser.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var user in kvp.Value.OrderBy(u => u))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
