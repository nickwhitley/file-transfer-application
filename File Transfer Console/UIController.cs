using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_Console
{
    internal class UIController
    {
        Data data;

        public UIController(Data sessionData)
        {
            data = sessionData;
        }

        public bool AskForSourceFolder()
        {
            Console.WriteLine("Enter source folder path:");
            string sourceFolderPath = Console.ReadLine();
            if (Directory.Exists(sourceFolderPath))
            {
                data.SourceFolderPath = sourceFolderPath;
                data.NumOfSourceFiles = Directory.GetFiles(sourceFolderPath).Length;
                Console.WriteLine($"Source folder found. Contains { data.NumOfSourceFiles } file(s).\n");
                return true;
            }
            else
            {
                Console.WriteLine("Source folder not found.");
                return AskForSourceFolder();
            }
        }

        public bool AskForTargetFolder()
        {
            Console.WriteLine("Enter target folder path:");
            string targetFolderPath = Console.ReadLine();
            if (Directory.Exists(targetFolderPath))
            {
                data.TargetFolderPath = targetFolderPath;
                data.NumOfTargetFolderFiles = Directory.GetFiles(targetFolderPath).Length;
                Console.WriteLine($"Target folder found. Contains { data.NumOfTargetFolderFiles } file(s).\n");
                return true;
            }
            else
            {
                Console.WriteLine("Target folder not found.");
                return AskForTargetFolder();
            }
        }

        public void PrintFolderConfirmation()
        {
            Console.WriteLine($"Source folder: { data.SourceFolderPath }");
            Console.WriteLine($"Target folder: { data.TargetFolderPath }");
            Console.WriteLine($"Press ENTER to begin transfer of { data.NumOfSourceFiles } file(s) to target folder.\n");
        }

        public void CheckForEnterPress()
        {
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Beginning Transfer...");
                try
                {
                    data.TransferFiles();
                    Console.WriteLine("Transfer complete.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error transferring files.");
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
