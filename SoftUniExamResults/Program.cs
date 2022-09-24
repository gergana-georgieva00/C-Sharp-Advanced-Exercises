using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> usernamePoints = new Dictionary<string, int>();
            Dictionary<string, List<string>> languageUser = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] spl = command.Split("-");

                string username;

                if (command.Contains("banned"))
                {
                    username = spl[0];
                    usernamePoints.Remove(username);

                    continue;
                }

                username = spl[0];
                string language = spl[1];
                int points = int.Parse(spl[2]);

                if (!usernamePoints.ContainsKey(username))
                {
                    usernamePoints.Add(username, points);
                }

                if (usernamePoints[username] < points)
                {
                    usernamePoints[username] = points;
                }

                if (!languageUser.ContainsKey(language))
                {
                    languageUser.Add(language, new List<string>());
                }

                languageUser[language].Add(username);
            }

            Console.WriteLine("Results:");

            foreach (var kvp in usernamePoints.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in languageUser.OrderByDescending(l => l.Value.Count).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Count}");
            }
        }
    }
}
