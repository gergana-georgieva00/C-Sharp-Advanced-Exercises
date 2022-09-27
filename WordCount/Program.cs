using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            // TODO: write your code here…
            string pattern = @"[a-zA-z]+";

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            List<string> allWordsText = new List<string>();

            using (StreamReader readerWords = new StreamReader(wordsFilePath))
            {
                while (!readerWords.EndOfStream)
                {
                    string currLine = readerWords.ReadLine();

                    foreach (var word in currLine.Split())
                    {
                        wordCount.Add(word, 0);
                    }
                }

                using (StreamReader readerText = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (!readerText.EndOfStream)
                        {
                            string currLine = readerText.ReadLine();

                            MatchCollection matches = Regex.Matches(currLine, pattern);

                            foreach (Match match in matches)
                            {
                                if (match.Success)
                                {
                                    string currMatch = match.Groups[0].Value;
                                    allWordsText.Add(currMatch);
                                }
                            }
                        }
                    }
                }
            }

            foreach (var word in allWordsText)
            {
                if (wordCount.ContainsKey(word.ToLower()))
                {
                    wordCount[word.ToLower()]++;
                }
            }

            foreach (var kvp in wordCount.OrderByDescending(w => w.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
