using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleInvited = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<Tuple<string, Func<string, bool>>> filters = new List<Tuple<string, Func<string, bool>>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] spl = input.Split(';');

                string command = spl[0];
                string filterType = spl[1];
                string filterParameter = spl[2];

                if (command == "Add filter")
                {
                    if (filterType == "Starts with")
                    {
                        var startsWithFunctionCode = "s" + filterParameter;
                        Func<string, bool> newFunc = name => name.StartsWith(filterParameter);
                        filters.Add(new Tuple<string, Func<string, bool>>(startsWithFunctionCode, newFunc));
                    }
                    else if (filterType == "Ends with")
                    {
                        var startsWithFunctionCode = "e" + filterParameter;
                        Func<string, bool> newFunc = name => name.EndsWith(filterParameter);
                        filters.Add(new Tuple<string, Func<string, bool>>(startsWithFunctionCode, newFunc));
                    }
                    else if (filterType == "Length")
                    {
                        var startsWithFunctionCode = "l" + filterParameter;
                        Func<string, bool> newFunc = name => name.Length == int.Parse(filterParameter);
                        filters.Add(new Tuple<string, Func<string, bool>>(startsWithFunctionCode, newFunc));
                    }
                    else
                    {
                        var startsWithFunctionCode = "c" + filterParameter;
                        Func<string, bool> newFunc = name => name.Contains(filterParameter);
                        filters.Add(new Tuple<string, Func<string, bool>>(startsWithFunctionCode, newFunc));
                    }
                }
                else
                {
                    if (filterType == "Starts with")
                    {
                        filters = filters.Where(f => f.Item1 != "s" + filterParameter).ToList();
                    }
                    else if (filterType == "Ends with")
                    {
                        filters = filters.Where(f => f.Item1 != "e" + filterParameter).ToList();
                    }
                    else if (filterType == "Length")
                    {
                        filters = filters.Where(f => f.Item1 != "l" + filterParameter).ToList();
                    }
                    else
                    {
                        filters = filters.Where(f => f.Item1 != "c" + filterParameter).ToList();
                    }
                }
            }

            foreach (var filter in filters)
            {
                peopleInvited = peopleInvited.Where(p => !filter.Item2(p)).ToList();
            }

            Console.WriteLine(string.Join(' ', peopleInvited));
        }
    }
}
