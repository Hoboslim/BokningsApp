using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BokningsApp.Models;
using BokningsApp.Data;
using MongoDB.Driver;
using MongoDB.Bson; 

namespace BokningsApp.ViewModels
{
    public class BookingHistoryViewModel
    {
        public ObservableCollection<Bookings> OldBookings { get; set; } = new();
        public ObservableCollection<Rooms> BookedRooms { get; set; } = new();
        public ObservableCollection<Bookings> UserBookings { get; set; } = new();
        public BookingHistoryViewModel() { }

        public async Task LoadOldBookings()
        {
            var oldBookings = await DB.GetBookingCollection()
                .Find(b => b.EndTime < System.DateTime.UtcNow)
                .ToListAsync();
            OldBookings = new ObservableCollection<Bookings>(oldBookings);
        }

        public async Task LoadBookedRooms()
        {
            var bookedRooms = await DB.GetRoomCollection()
                .Find(r => r.Bookings.Count > 0)
                .ToListAsync();
            BookedRooms = new ObservableCollection<Rooms>(bookedRooms);
        }

        public async Task LoadUserBookings(ObjectId loggedInUserId)
        {
            var userBookings = await DB.GetBookingCollection()
                .Find(b => b.UserId == loggedInUserId)
                .ToListAsync();

            UserBookings.Clear();
            foreach (var booking in userBookings)
            {
                UserBookings.Add(booking);
            }
        }
    }
}
