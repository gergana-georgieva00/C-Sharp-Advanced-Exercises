using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            char[] pear = new char[4];
            char[] flour = new char[5];
            char[] pork = new char[4];
            char[] olive = new char[5];

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                char currConsonanat = consonants.Pop();

                vowels.Enqueue(currVowel);

                if (currVowel == 'e' || currVowel == 'a' || currVowel == 'o' || currVowel == 'u' || currVowel == 'i')
                {
                    switch (currVowel)
                    {
                        case 'e':
                            if (pear[1] != 'e')
                            {
                                pear[1] = 'e';
                            }
                            if (olive[4] != 'e')
                            {
                                olive[4] = 'e';
                            }
                            break;
                        case 'a':
                            if (pear[2] != 'a')
                            {
                                pear[2] = 'a';
                            }
                            break;
                        case 'o':
                            if (flour[2] != 'o')
                            {
                                flour[2] = 'o';
                            }
                            if (pork[1] != 'o')
                            {
                                pork[1] = 'o';
                            }
                            if (olive[0] != 'o')
                            {
                                olive[0] = 'o';
                            }
                            break;
                        case 'u':
                            if (flour[3] != 'u')
                            {
                                flour[3] = 'u';
                            }
                            break;
                        case 'i':
                            if (olive[2] != 'i')
                            {
                                olive[2] = 'i';
                            }
                            break;
                    }
                }

                if (currConsonanat == 'p' || currConsonanat == 'r' || currConsonanat == 'f' || currConsonanat == 'l' ||
                    currConsonanat == 'k' || currConsonanat == 'v')
                {
                    switch (currConsonanat)
                    {
                        case 'p':
                            if (pear[0] != 'p')
                            {
                                pear[0] = 'p';
                            }
                            if (pork[0] != 'p')
                            {
                                pork[0] = 'p';
                            }
                            break;
                        case 'r':
                            if (pear[3] != 'p')
                            {
                                pear[3] = 'p';
                            }
                            if (flour[4] != 'p')
                            {
                                flour[4] = 'p';
                            }
                            if (pork[2] != 'p')
                            {
                                pork[2] = 'p';
                            }
                            break;
                        case 'f':
                            if (flour[0] != 'f')
                            {
                                flour[0] = 'f';
                            }
                            break;
                        case 'l':
                            if (flour[1] != 'l')
                            {
                                flour[1] = 'l';
                            }
                            if (olive[1] != 'l')
                            {
                                olive[1] = 'l';
                            }
                            break;
                        case 'k':
                            if (pork[3] != 'k')
                            {
                                pork[3] = 'k';
                            }
                            break;
                        case 'v':
                            if (olive[3] != 'v')
                            {
                                olive[3] = 'v';
                            }
                            break;
                    }
                }
            }

            int words = 0;
            List<string> allWords = new List<string>();

            if (pear[0] != default(char) && pear[1] != default(char) && pear[2] != default(char) && pear[3] != default(char))
            {
                words++;
                allWords.Add("pear");
            }

            if (flour[0] != default(char) && flour[1] != default(char) && flour[2] != default(char) && flour[3] != default(char) && flour[4] != default(char))
            {
                words++;
                allWords.Add("flour");
            }

            if (pork[0] != default(char) && pork[1] != default(char) && pork[2] != default(char) && pork[3] != default(char))
            {
                words++;
                allWords.Add("pork");
            }

            if (olive[0] != default(char) && olive[1] != default(char) && olive[2] != default(char) && olive[3] != default(char) && olive[4] != default(char))
            {
                words++;
                allWords.Add("olive");
            }

            Console.WriteLine($"Words found: {words}");
            Console.WriteLine($"{string.Join(Environment.NewLine, allWords)}");
        }
    }
}
