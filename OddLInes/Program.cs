using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            // TODO: write your code here…
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int currRow = 0;

                    while (!reader.EndOfStream)
                    {
                        string currLine = reader.ReadLine();

                        if (currRow % 2 == 1)
                        {
                            writer.WriteLine(currLine);
                        }

                        currRow++;
                    }
                }
            }
        }
    }
}
