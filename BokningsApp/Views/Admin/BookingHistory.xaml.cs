using BokningsApp.ViewModels;
using System.Threading.Tasks;

namespace BokningsApp.Admin
{
    public partial class BookingHistory : ContentPage
    {
        private readonly BookingHistoryViewModel _viewModel;

        public BookingHistory()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            BindingContext = _viewModel;
            LoadHistoryAsync();
        }

        private async void LoadHistoryAsync()
        {
            await _viewModel.LoadOldBookings();
        }
    }
}
