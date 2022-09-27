using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(c => char.IsLetter(c));
                int puncMarksCount = lines[i].Count(p => char.IsPunctuation(p));

                sb.AppendLine($"Line {i + 1}: {lines[i]} ({lettersCount})({puncMarksCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }

}
