using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            // TODO: write your code here…

            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        bool str1 = false;
                        bool str2 = false;

                        while (true)
                        {
                            if (!reader1.EndOfStream)
                            {
                                string line1 = reader1.ReadLine();
                                writer.WriteLine(line1);
                            }
                            else
                            {
                                str1 = true;
                            }

                            if (!reader2.EndOfStream)
                            {
                                string line2 = reader2.ReadLine();
                                writer.WriteLine(line2);
                            }
                            else
                            {
                                str2 = true;
                            }

                            if (str1 && str2)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
