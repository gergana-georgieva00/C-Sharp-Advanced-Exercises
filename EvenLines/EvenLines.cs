namespace EvenLines
{
    using System;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    string currLine = reader.ReadLine();
                    currLine = currLine.Replace('-', '@');
                    currLine = currLine.Replace(',', '@');
                    currLine = currLine.Replace('.', '@');
                    currLine = currLine.Replace('!', '@');
                    currLine = currLine.Replace('?', '@');

                    string[] words = currLine.Split();

                    if (counter % 2 == 0)
                    {
                        for (int i = words.Length - 1; i >= 0; i--)
                        {
                            sb.Append(words[i] + " ");
                        }

                        sb.AppendLine();
                    }

                    counter++;
                }
            }

            return sb.ToString();
        }
    }
}
