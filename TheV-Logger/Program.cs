using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggersAndFollowers = new Dictionary<string, List<string>>();
            Dictionary<string, int> vloggersFollowCount = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                if (command.Contains("joined"))
                {
                    string vloggername = command.Split()[0];

                    if (!vloggersAndFollowers.ContainsKey(vloggername))
                    {
                        vloggersAndFollowers.Add(vloggername, new List<string>());
                        vloggersFollowCount.Add(vloggername, 0);
                    }
                }
                else
                {
                    string vloggername1 = command.Split()[0];
                    string vloggername2 = command.Split()[2];

                    if (vloggersAndFollowers.ContainsKey(vloggername1) && vloggersAndFollowers.ContainsKey(vloggername2) 
                        && vloggername1 != vloggername2)
                    {
                        if (!vloggersAndFollowers[vloggername2].Contains(vloggername1))
                        {
                            vloggersAndFollowers[vloggername2].Add(vloggername1);
                            vloggersFollowCount[vloggername1]++;
                        }
                    }
                }
            }

            vloggersAndFollowers = vloggersAndFollowers.OrderByDescending(v => v.Value.Count).ThenBy(v => vloggersFollowCount[v.Key]).ToDictionary(v => v.Key, v => v.Value);
            vloggersFollowCount = vloggersFollowCount.OrderBy(v => v.Value).ToDictionary(v => v.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggersAndFollowers.Keys.Count} vloggers in its logs.");

            int counter = 1;
            foreach (var kvp in vloggersAndFollowers)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value.Count} followers, {vloggersFollowCount[kvp.Key]} following");

                if (counter == 1)
                {
                    foreach (var follower in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
