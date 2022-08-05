using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_WPF.Models
{
    internal class TransferModel : ITransferModel
    {
        private string _sourceFolderPath;
        private string _targetFolderPath;
        private string _sourceFileCount;
        private string _targetFileCount;
        private string _errorMessage;
        private BindableCollection<string> _sourceFilesList = new BindableCollection<string>();
        private BindableCollection<string> _targetFilesList = new BindableCollection<string>();
        private BindableCollection<FileModel> _files = new BindableCollection<FileModel>();

        public void CommitFileTransfer(string sourceFolder, string destinationFolder)
        {
            throw new NotImplementedException();
        }

        public string SourceFolderPath
        {
            get => _sourceFolderPath;
            set
            {
                _sourceFolderPath = value;
            }
        }
        public string TargetFolderPath
        {
            get => _targetFolderPath;
            set
            {
                _targetFolderPath = value;
            }
        }
        public string SourceFileCount
        {
            get => _sourceFileCount;
            set
            {
                _sourceFileCount = value;
            }
        }
        public string TargetFileCount
        {
            get => _targetFileCount;
            set
            {
                _targetFileCount = value;
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
            }
        }
        public BindableCollection<string> SourceFilesList
        {
            get => _sourceFilesList;
            set
            {
                _sourceFilesList = value;
            }
        }
        public BindableCollection<string> TargetFilesList
        {
            get => _targetFilesList;
            set
            {
                _targetFilesList = value;
            }
        }
        public BindableCollection<FileModel> Files
        {
            get => _files;
            set
            {
                _files = value;
            }
        }

        public TransferModel()
        {

        }

        
    }
}
