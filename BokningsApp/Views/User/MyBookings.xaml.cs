using BokningsApp.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MongoDB.Bson;
using BokningsApp.Data;
using BokningsApp.ViewModels;

namespace BokningsApp.Views.User
{
    public partial class MyBookings : ContentPage
    {
        private readonly BookingHistoryViewModel _viewModel;

        public MyBookings(ObjectId loggedInUserId)
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel();
            BindingContext = _viewModel;

            Task.Run(async () => await _viewModel.LoadUserBookings());
        }
    }
}


