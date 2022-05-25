using Caliburn.Micro;
using File_Transfer_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Transfer_WPF.ViewModels
{
    internal class TransferViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private ITransferModel _transferModel;
        public TransferViewModel(IEventAggregator eventAggregator, ITransferModel transferModel)
        {
            _eventAggregator = eventAggregator;
            _transferModel = transferModel;
        }
    }
}
