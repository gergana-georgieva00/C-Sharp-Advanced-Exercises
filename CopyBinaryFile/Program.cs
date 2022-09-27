namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream reader = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[reader.Length];
                    reader.Read(buffer, 0, (int)reader.Length);

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        writer.Write(new byte[] { buffer[i] });
                    }
                }
            }
        }
    }
}
