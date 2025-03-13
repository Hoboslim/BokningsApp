using BokningsApp.ViewModels;
using System.Threading.Tasks;

namespace BokningsApp.Admin
{
    public partial class BookingHistory : ContentPage
    {
        private BookingHistoryViewModel _viewModel;

        public BookingHistory()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            _ = LoadHistoryAsync();
        }

        private async Task LoadHistoryAsync()
        {
            await Task.Run(() => _viewModel.LoadOldBookings());
            BindingContext = _viewModel;
        }
    }
}
