using BokningsApp.ViewModels;
using System.Threading.Tasks;

namespace BokningsApp.Admin
{
    public partial class BookedRooms : ContentPage
    {
        private BookingHistoryViewModel _viewModel;

        public BookedRooms()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            _ = LoadRoomsAsync();
        }

        private async Task LoadRoomsAsync()
        {
            await Task.Run(() => _viewModel.LoadBookedRooms());
            BindingContext = _viewModel;
        }
    }
}
