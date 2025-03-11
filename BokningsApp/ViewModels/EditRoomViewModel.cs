using BokningsApp.Data;
using BokningsApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsApp.ViewModels
{
    internal class EditRoomViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<RoomTypes> _roomTypes;
        private RoomTypes _selectedRoomTypes;
        private Rooms _room;

        public ObservableCollection<RoomTypes> RoomTypes
        {
            get => _roomTypes;
            set
            {
                _roomTypes = value;
                OnPropertyChanged(nameof(RoomTypes));
            }

        }
        public RoomTypes SelectedRoomType
        {
            get => _selectedRoomTypes;
            set
            {
                _selectedRoomTypes = value;
                OnPropertyChanged(nameof(SelectedRoomType));
            }
        }
        public Rooms Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }

        public EditRoomViewModel()
        {
            LoadRoomTypesAsync();
        }

        private async void LoadRoomTypesAsync()
        {
            var roomTypesCollection = DB.GetRoomTypesCollection();

            var roomTypes = await roomTypesCollection.Find(FilterDefinition<Models.RoomTypes>.Empty).ToListAsync();
            RoomTypes = new ObservableCollection<RoomTypes>(roomTypes);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task SaveRoomChangesAsync()
        {
            var roomCollection = DB.GetRoomCollection();
            var filter = Builders<Rooms>.Filter.Eq(r => r.Id, Room.Id);
            var update = Builders<Rooms>.Update
                .Set(r => r.RoomName, Room.RoomName)
                .Set(r => r.RoomType, Room.RoomType)
                .Set(r => r.RoomDescription, Room.RoomDescription)
                .Set(r => r.Slots, Room.Slots);
            await roomCollection.UpdateOneAsync(filter, update);
        }
    }
}
