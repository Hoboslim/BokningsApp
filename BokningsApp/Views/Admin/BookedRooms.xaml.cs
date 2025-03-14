using BokningsApp.ViewModels;
using System.Threading.Tasks;

namespace BokningsApp.Admin
{
    public partial class BookedRooms : ContentPage
    {
        private readonly BookingHistoryViewModel _viewModel;

        public BookedRooms()
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            BindingContext = _viewModel;
            LoadRoomsAsync();
        }

        private async void LoadRoomsAsync()
        {
            //await _viewModel.LoadBookedRooms();
        }
    }
}
