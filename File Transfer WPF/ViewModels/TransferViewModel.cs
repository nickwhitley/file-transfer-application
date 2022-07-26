using Caliburn.Micro;
using File_Transfer_WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace File_Transfer_WPF.ViewModels
{
    internal class TransferViewModel : Screen , INotifyPropertyChanged
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
            SetSourceFileCount(dialog.SelectedPath);
        }

        private void SetSourceFileCount(string selectedPath)
        {
            if (Directory.Exists(selectedPath))
            {
                int numOfFiles = Directory.GetFiles(selectedPath).Length;
                SourceFileCount = numOfFiles.ToString();
            }
        }

        public void TargetBrowseClick()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Target Folder path select.";
            dialog.ShowDialog();
            TargetFolderPath = dialog.SelectedPath;
            SetTargetFileCount(dialog.SelectedPath);
        }

        private void SetTargetFileCount(string selectedPath)
        {
            if (Directory.Exists(selectedPath))
            {
                int numOfFiles = Directory.GetFiles(selectedPath).Length;
                TargetFileCount = numOfFiles.ToString();
            }
        }
    }
}
