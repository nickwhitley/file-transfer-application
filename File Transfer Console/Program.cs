// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please enter origin folder path:");
string originFolderPath = Console.ReadLine();
Console.WriteLine("Please enter transfer folder path:");
string transferFolderPath = Console.ReadLine();
Console.WriteLine($"\nOrigin Folder Path: {originFolderPath}" +
    $"\nTransfer Folder Path: {transferFolderPath}" +
    $"\npress ENTER to begin transfer.");
if(Console.ReadKey().Key == ConsoleKey.Enter)
{
    Console.WriteLine("Beginning Transfer...");
}

