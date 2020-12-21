using System;
using System.IO;

namespace FileScannerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path");
            var dirPath = @"" + Console.ReadLine();

            if (File.Exists(dirPath))
            {
                string filePath = new DirectoryInfo(dirPath).ToString();
                try
                {
                    string fileName = Path.GetFileName(filePath);
                    var re = FileUploaderHelper.UploadFileAndScanQRCode(filePath, fileName);
                    Console.WriteLine(re);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            else
            {
                Console.WriteLine("Invalid File Path");
            }

        }
    }
}
