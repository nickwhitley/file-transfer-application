using Caliburn.Micro;
using File_Transfer_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace File_Transfer_WPF.ViewModels
{
    internal class TransferViewModel : Screen, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IEventAggregator _eventAggregator;
        private ITransferModel _transferModel;
        private readonly IWindowManager _windowManager;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _sourceFolderPath;
        private string _targetFolderPath;
        private string _sourceFileCount;
        private string _targetFileCount;
        private string _errorMessage;
        private BindableCollection<string> _sourceFilesList = new BindableCollection<string>();
        private BindableCollection<string> _targetFilesList = new BindableCollection<string>();
        private BindableCollection<FileModel> _files = new BindableCollection<FileModel>();

        public string SourceFolderPath
        {
            get => _sourceFolderPath;
            set
            {
                _sourceFolderPath = value;
                OnPropertyChanged("SourceFolderPath");
            }
        }
        public string TargetFolderPath
        {
            get => _targetFolderPath;
            set
            {
                _targetFolderPath = value;
                OnPropertyChanged("TargetFolderPath");
            }
        }
        public string SourceFileCount
        {
            get => _sourceFileCount;
            set
            {
                _sourceFileCount = value;
                OnPropertyChanged("SourceFileCount");
            }
        }
        public string TargetFileCount
        {
            get => _targetFileCount;
            set
            {
                _targetFileCount = value;
                OnPropertyChanged("TargetFileCount");
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        public BindableCollection<string> SourceFilesList
        {
            get => _sourceFilesList;
            set
            {
                _sourceFilesList = value;
                OnPropertyChanged("SourceFilesList");
            }
        }
        public BindableCollection<string> TargetFilesList
        {
            get => _targetFilesList;
            set
            {
                _targetFilesList = value;
                OnPropertyChanged("TargetFilesList");
            }
        }

        public BindableCollection<FileModel> Files
        {
            get => _files;
            set
            {
                _files = value;
                OnPropertyChanged("Files");
            }
        }

        public TransferViewModel(IEventAggregator eventAggregator, ITransferModel transferModel)
        {
            _eventAggregator = eventAggregator;
            _transferModel = transferModel;
            this._windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.ResizeMode = ResizeMode.NoResize;

        }

        public void SourceBrowseClick()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Source Folder path select.";
            dialog.ShowDialog();
            SourceFolderPath = dialog.SelectedPath;
            SetSourceFileCount();
            PopulateSourceFilesList();
            PopulateFilesList();
        }

        private void SetSourceFileCount()
        {
            if (Directory.Exists(SourceFolderPath))
            {
                int numOfFiles = Directory.GetFiles(SourceFolderPath).Length;
                SourceFileCount = numOfFiles.ToString();
            }
        }

        public void TargetBrowseClick()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Target Folder path select.";
            dialog.ShowDialog();
            TargetFolderPath = dialog.SelectedPath;
            SetTargetFileCount();
            PopulateTargetFilesList();
        }

        private void SetTargetFileCount()
        {
            if (Directory.Exists(TargetFolderPath))
            {
                int numOfFiles = Directory.GetFiles(TargetFolderPath).Length;
                TargetFileCount = numOfFiles.ToString();
            }
        }

        public void TransferClick()
        {
            ErrorMessage = " ";
            if (!ErrorCheck())
            {
                return;
            }
            else

                TransferFiles();

            SetSourceFileCount();
            SetTargetFileCount();
        }

        private bool ErrorCheck()
        {
            if (TargetFolderPath == null || TargetFolderPath.Length == 0)
            {
                ErrorMessage = "Invalid target folder path.";
                return false;
            }
            else if (SourceFolderPath == null || SourceFolderPath.Length == 0)
            {
                ErrorMessage = "Invalid source folder path.";
                return false;
            }
            else if (SourceFileCount.Equals(0))
            {
                ErrorMessage = "There are 0 files in the source folder.";
                return false;
            }

            return true;
        }

        private void TransferFiles()
        {
            foreach (var file in Directory.GetFiles(SourceFolderPath))
            {
                string fileName = Path.GetFileName(file);
                string fileExtension = Path.GetExtension(file);
                if (FileIsSelected(fileExtension))
                {
                    File.Move(file, TargetFolderPath + "\\" + fileName);
                }
            }
            PopulateSourceFilesList();
            PopulateTargetFilesList();
        }

        private bool FileIsSelected(string fileExtension)
        {
            var fileModel = Files.Where(fileModel => fileModel.Extension == fileExtension).First();
            
            if (fileModel.IsSelected)
            {
                return true;
            } 
            else
                return false;

        }

        private void PopulateSourceFilesList()
        {
            SourceFilesList.Clear();
            if (Directory.Exists(SourceFolderPath))
            {
                var newList = new BindableCollection<string>();
                foreach (var file in Directory.GetFiles(SourceFolderPath))
                {

                    string fileName = Path.GetFileName(file);
                    newList.Add(fileName);
                }
                foreach(var folder in Directory.GetDirectories(SourceFolderPath))
                {
                    string folderName = Path.GetFileName(folder);
                    newList.Add($"{ folderName }.folder");
                }
                SourceFilesList = newList;
            }
        }

        private void PopulateTargetFilesList()
        {
            TargetFilesList.Clear();
            if (Directory.Exists(TargetFolderPath))
            {
                var newList = new BindableCollection<string>();

                foreach(var file in Directory.GetFiles(TargetFolderPath))
                {
                    string fileName = Path.GetFileName(file);
                    newList.Add(fileName);
                }
                TargetFilesList = newList;
            }
        }

        private void PopulateFilesList()
        {
            var newList = new BindableCollection<FileModel>();
            var extensionsList = new Collection<string>();

            foreach(var file in Directory.GetFiles(SourceFolderPath))
            {
                string extension = Path.GetExtension(file);
                
                if (!extensionsList.Contains(extension))
                {
                    extensionsList.Add(extension);
                    var newFileRecord = new FileModel { Extension = extension };
                    newList.Add(newFileRecord);
                }
            }
            Files = newList;
        }

        public void UpdateFileList(FileModel fileModel)
        {
            if(fileModel.IsSelected == false)
            {
                fileModel.IsSelected = true;
            } else 
                fileModel.IsSelected = false;
        }
    }
}
