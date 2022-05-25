using Caliburn.Micro;
using File_Transfer_WPF.Models;
using System.Threading;
using System.Threading.Tasks;

namespace File_Transfer_WPF.ViewModels
{
    internal class ShellViewModel: Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly TransferViewModel _transferViewModel;

        public ShellViewModel(IEventAggregator eventAggregator, TransferViewModel transferViewModel,
                                ITransferModel transferModel)
        {
            _eventAggregator = eventAggregator;
            _transferViewModel = transferViewModel;

            Items.AddRange(new Screen[] { transferViewModel });
        }

        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            _eventAggregator.SubscribeOnPublishedThread(this);
            ActivateItemAsync(_transferViewModel);
            return base.OnActivateAsync(cancellationToken);
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            _eventAggregator.Unsubscribe(this);
            return base.OnDeactivateAsync(close, cancellationToken);
        }
    }
}
