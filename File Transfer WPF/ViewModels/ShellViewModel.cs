using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace File_Transfer_WPF.ViewModels
{
    internal class ShellViewModel: Conductor<Screen>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly TransferViewModel _transferViewModel;

        public ShellViewModel(IEventAggregator eventAggregator, TransferViewModel transferViewModel)
        {
            _eventAggregator = eventAggregator;
            _transferViewModel = transferViewModel;
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ActivateItemAsync(_transferViewModel);
            return base.OnActivateAsync(cancellationToken);
        }
    }
}
