using Caliburn.Micro;
using System.ComponentModel;

namespace File_Transfer_WPF.Models
{
    internal interface ITransferModel
    {
        string ErrorMessage { get; set; }
        BindableCollection<FileModel> Files { get; set; }
        string SourceFileCount { get; set; }
        BindableCollection<string> SourceFilesList { get; set; }
        string SourceFolderPath { get; set; }
        string TargetFileCount { get; set; }
        BindableCollection<string> TargetFilesList { get; set; }
        string TargetFolderPath { get; set; }

        void CommitFileTransfer(string sourceFolder, string destinationFolder);
    }
}