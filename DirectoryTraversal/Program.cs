namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensions = new SortedDictionary<string, List<FileInfo>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!extensions.ContainsKey(fileInfo.Extension)) 
                {
                    extensions.Add(fileInfo.Extension, new List<FileInfo>());
                }

                extensions[fileInfo.Extension].Add(fileInfo);
            }

            var ordextensions = extensions.OrderByDescending(f => f.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var extFile in extensions)
            {
                sb.AppendLine(extFile.Key);

                var ordFiles = extFile.Value.OrderByDescending(f => f.Length);

                foreach (var file in ordFiles)
                {
                    sb.AppendLine($"=={file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}
