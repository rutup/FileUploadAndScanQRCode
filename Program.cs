using System;

namespace FileScannerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;
           
            try
            {
                filePath = @"D:\Development\TransPerfect\FileScannerApp\download.png";
                string fileName = "download.png";
                var re = FileUploaderHelper.UploadFileAndScanQRCode(filePath, fileName);
                Console.WriteLine(re);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
    }
}
