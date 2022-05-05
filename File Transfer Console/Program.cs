// See https://aka.ms/new-console-template for more information
using File_Transfer_Console;
using System.IO;

Data data = new Data();
UIController controller = new UIController(data);

controller.AskForSourceFolder();
controller.AskForTargetFolder();
controller.PrintFolderConfirmation();
controller.CheckForEnterPress();

