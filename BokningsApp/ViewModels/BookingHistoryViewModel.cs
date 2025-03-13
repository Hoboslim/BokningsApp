using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BokningsApp.Models;
using BokningsApp.Data;
using MongoDB.Driver;

namespace BokningsApp.ViewModels
{
    public class BookingHistoryViewModel
    {
        public ObservableCollection<Bookings> OldBookings { get; set; } = new();
        public ObservableCollection<Rooms> BookedRooms { get; set; } = new();

        public BookingHistoryViewModel() { }

        public async void LoadOldBookings()
        {
            var oldBookings = await DB.GetBookingCollection()
                .Find(b => b.EndTime < System.DateTime.UtcNow)
                .ToListAsync();
            OldBookings = new ObservableCollection<Bookings>(oldBookings);
        }


        public async void LoadBookedRooms()
        {
            var bookedRooms = await DB.GetRoomCollection()
                .Find(r => r.Bookings.Count > 0)
                .ToListAsync();
            BookedRooms = new ObservableCollection<Rooms>(bookedRooms);
        }




    }
}
