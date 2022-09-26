using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            // TODO: write your code here…

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int num = 1;

                    while (!reader.EndOfStream)
                    {
                        string currLine = reader.ReadLine();

                        writer.WriteLine($"{num.ToString()}. {currLine}");

                        num++;
                    }
                }
            }
        }
    }
}
