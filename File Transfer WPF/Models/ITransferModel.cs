namespace File_Transfer_WPF.Models
{
    internal interface ITransferModel
    {
        string DestinationFolderPath { get; set; }
        string FileTypes { get; set; }
        string SourceFolderPath { get; set; }

        void CommitFileTransfer(string sourceFolder, string destinationFolder);
    }
}