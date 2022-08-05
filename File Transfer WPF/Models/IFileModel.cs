namespace File_Transfer_WPF.Models
{
    internal interface IFileModel
    {
        string Extension { get; set; }
        bool IsSelected { get; set; }
    }
}