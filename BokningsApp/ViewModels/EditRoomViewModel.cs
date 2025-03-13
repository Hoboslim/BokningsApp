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
    public class EditRoomViewModel : INotifyPropertyChanged
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

        public async void LoadRoomTypesAsync()
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
    }
}
