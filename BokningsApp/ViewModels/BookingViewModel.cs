using BokningsApp.Data;
using BokningsApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BokningsApp.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<RoomTypes> RoomTypes { get; set; } = new ObservableCollection<RoomTypes>();
        public ObservableCollection<Rooms> AvailableRooms { get; set; } = new ObservableCollection<Rooms>();


        private string _selectedDate;
        private RoomTypes _SelectedRoomTypes;
        private Rooms _selectedRooms;
        private TimeSpan _startTime;
        private TimeSpan _endTime;

        private TimeSpan _minimumTime = new TimeSpan(9, 0, 0);
        private TimeSpan _maximumTime = new TimeSpan(17, 0, 0);


        public string SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public RoomTypes SelectedRoomType
        {
            get => _SelectedRoomTypes;
            set
            {
                if (_SelectedRoomTypes != value)
                {
                    _SelectedRoomTypes = value;
                    OnPropertyChanged(nameof(SelectedRoomType));
                }
                LoadRoomsForRoomType(value);
            }
        }

        public Rooms SelectedRoom
        {
            get => _selectedRooms;
            set
            {
                _selectedRooms = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public TimeSpan StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
                
            }
                
        } public TimeSpan EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
                
            }
                
        }

        public BookingViewModel(string selectedDate)
        {
            _selectedDate = selectedDate;
            LoadRoomTypes();
        }

        public async Task LoadRoomTypes()
        {
            var roomTypesCollection = DB.GetRoomTypesCollection();
            var roomTypes = await roomTypesCollection.Find(FilterDefinition<RoomTypes>.Empty).ToListAsync();

            RoomTypes.Clear();

            foreach(var roomType in roomTypes)
            {
                RoomTypes.Add(roomType);
            }
        }

        private async void LoadRoomsForRoomType(RoomTypes roomType)
        {
            if (roomType != null)
            {
                var roomsCollection = DB.GetRoomsCollection();
                var rooms = await roomsCollection
                    .Find(r => r.RoomType == roomType.RoomType)
                    .ToListAsync();
                AvailableRooms.Clear();
                foreach(var room in rooms)
                {
                    AvailableRooms.Add(room);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
