// See https://aka.ms/new-console-template for more information
using System.IO;

//ask for first folder, which would be the origin folder.
Console.WriteLine("Please enter origin folder path:");
string originFolderPath = @"M:\Documents\Coding\C#\projects\FileTransferApplication\TestOriginFolder";
string[] originFiles = Directory.GetFiles(originFolderPath);

//check if folder exists and print num of files.
if (Directory.Exists(originFolderPath))
{
    int numOfFiles = originFiles.Length;
    Console.WriteLine("folder found.");
    Console.WriteLine($"There are {numOfFiles} file(s) in folder.");

} else
{
    Console.WriteLine("folder not found.");
}

//ask for second folder, which would be the transfer folder.
Console.WriteLine("Please enter transfer folder path:");
string transferFolderPath = @"M:\Documents\Coding\C#\projects\FileTransferApplication\TestTransferFolder";
string[] transferFiles = Directory.GetFiles(transferFolderPath);

//check if folder exists and print num of files.
if (Directory.Exists(transferFolderPath))
{
    int numOfFiles = transferFiles.Length;
    Console.WriteLine("folder found.");
    Console.WriteLine($"There are {numOfFiles} file(s) in folder.");
}
else
{
    Console.WriteLine("folder not found.");
}


Console.WriteLine($"\nOrigin Folder Path: {originFolderPath}" +
    $"\nTransfer Folder Path: {transferFolderPath}" +
    $"\npress ENTER to begin transfer.");
if(Console.ReadKey().Key == ConsoleKey.Enter)
{
    Console.WriteLine("Beginning Transfer...");
    TransferFiles(originFolderPath, transferFolderPath);
}

void TransferFiles(string originFolder, string transferFolder)
{
    foreach(var file in Directory.GetFiles(originFolder))
    {
        string fileName = Path.GetFileName(file);
        File.Move(file, transferFolder + "\\" + fileName);
    }
}


