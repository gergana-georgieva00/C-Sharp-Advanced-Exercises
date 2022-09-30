using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = splitCommand[0];
                string criteria = splitCommand[1];
                string template = splitCommand[2];

                if (action == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            peopleComing.RemoveAll(p => p.StartsWith(template));
                            break;
                        case "EndsWith":
                            peopleComing.RemoveAll(p => p.EndsWith(template));
                            break;
                        default:
                            peopleComing.RemoveAll(p => p.Length == int.Parse(template));
                            break;
                    }
                }
                else
                {
                    string[] repeatingWords;

                    switch (criteria)
                    {
                        case "StartsWith":
                            repeatingWords = peopleComing.Where(p => p.StartsWith(template)).ToArray();
                            int count = repeatingWords.Where(p => p.StartsWith(template)).ToList().Count;

                            foreach (var wordToRepeat in repeatingWords)
                            {
                                foreach (var person in peopleComing)
                                {
                                    if (person.StartsWith(template))
                                    {
                                        int index = peopleComing.IndexOf(person);

                                        for (int i = 0; i < count; i++)
                                        {
                                            peopleComing.Insert(index, person);
                                        }

                                        break;
                                    }
                                }

                                break;
                            }
                            break;
                        case "EndsWith":
                            repeatingWords = peopleComing.Where(p => p.EndsWith(template)).ToArray();
                            int count2 = repeatingWords.Where(p => p.EndsWith(template)).ToList().Count;

                            foreach (var wordToRepeat in repeatingWords)
                            {
                                foreach (var person in peopleComing)
                                {
                                    if (person.EndsWith(template))
                                    {
                                        int index = peopleComing.IndexOf(person);

                                        for (int i = 0; i < count2; i++)
                                        {
                                            peopleComing.Insert(index, person);
                                        }

                                        break;
                                    }
                                }

                                break;
                            }
                            break;
                        default:
                            repeatingWords = peopleComing.Where(p => p.Length == int.Parse(template)).ToArray();
                            int count3 = repeatingWords.Where(p => p.Length == int.Parse(template)).ToList().Count;

                            foreach (var wordToRepeat in repeatingWords)
                            {
                                foreach (var person in peopleComing)
                                {
                                    if (person.Length == int.Parse(template))
                                    {
                                        int index = peopleComing.IndexOf(person);

                                        for (int i = 0; i < count3; i++)
                                        {
                                            peopleComing.Insert(index + 1, person);
                                        }

                                        break;
                                    }
                                }

                                break;
                            }
                            break;
                    }
                }
            }

            if (peopleComing.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", peopleComing)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
