using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                contestAndPassword.Add(input.Split(':')[0], input.Split(':')[1]);
            }

            Dictionary<string, List<string>> contestAndUsers = new Dictionary<string, List<string>>();
            Dictionary<string, Dictionary<string, int>> userAndPoints = new Dictionary<string, Dictionary<string, int>>();

            int mostPoints = int.MinValue;
            string maxUser = string.Empty;

            string submission;
            while ((submission = Console.ReadLine()) != "end of submissions")
            {
                string[] spl = submission.Split("=>");

                string contest = spl[0];
                string password = spl[1];
                string username = spl[2];
                int points = int.Parse(spl[3]);

                if (contestAndPassword.ContainsKey(contest) && contestAndPassword[contest] == password)
                {
                    if (contestAndUsers.ContainsKey(contest) && contestAndUsers[contest].Contains(username))
                    {
                        if (points > userAndPoints[username][contest])
                        {
                            userAndPoints[username][contest] = points;
                        }
                    }
                    else
                    {
                        if (!contestAndUsers.ContainsKey(contest))
                        {
                            contestAndUsers.Add(contest, new List<string>());
                        }
                        
                        contestAndUsers[contest].Add(username);
                        

                        if (!userAndPoints.ContainsKey(username))
                        {
                            userAndPoints.Add(username, new Dictionary<string, int>());
                        }

                        if (!userAndPoints[username].ContainsKey(contest))
                        {
                            userAndPoints[username].Add(contest, points);
                        }
                    }
                }
            }

            foreach (var kvp in userAndPoints)
            {
                int currP = 0;

                foreach (var contPo in kvp.Value)
                {
                    currP += contPo.Value;
                }

                if (currP > mostPoints)
                {
                    mostPoints = currP;
                    maxUser = kvp.Key;
                }
            }

            Console.WriteLine($"Best candidate is {maxUser} with total {mostPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var kvp in userAndPoints.OrderBy(u => u.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var item in kvp.Value.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
