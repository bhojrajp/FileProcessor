using System;
using System.Diagnostics;
using System.IO;

namespace FileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1 || args[0].Trim() == string.Empty)
            {
                Console.WriteLine("Please provide the file name and try again.....");
            }
            else
            {
                string fileName = args[0].Trim();
                string inputFilePath = System.Environment.CurrentDirectory + @"\Input\" + fileName;

                try
                {
                    if (File.Exists(inputFilePath))
                    {
                        DataProcessor fileProcessor = new DataProcessor(inputFilePath);
                        fileProcessor.PerformDataExtraction();
                        Console.WriteLine("File processed sucessfully...");
                    }
                    else
                    {
                        Console.WriteLine("Specified file does not exist...");
                        Console.WriteLine("Please try again with correct file name...");

                    }
                }
                catch (Exception ex)
                {
                    //trace can be repalced with custom logger
                    Trace.Write(ex.InnerException.ToString());
                    Console.WriteLine("Error while processing....!!!");
                }
            }

            Console.WriteLine("Press any key to exit the program!");
            Console.ReadKey();
        }
    }
}
