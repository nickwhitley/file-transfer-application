using Caliburn.Micro;
using File_Transfer_WPF.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace File_Transfer_WPF.ViewModels
{
    internal class TransferViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private ITransferModel _transferModel;
        private readonly IWindowManager _windowManager;
        public TransferViewModel(IEventAggregator eventAggregator, ITransferModel transferModel)
        {
            _eventAggregator = eventAggregator;
            _transferModel = transferModel;
            this._windowManager = new WindowManager();
            dynamic settings = new ExpandoObject();
            settings.ResizeMode = ResizeMode.NoResize;
            
        }

        public void BrowseClick()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            ///TODO put into ViewModel for dialog box
        }
    }
}
