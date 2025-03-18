using BokningsApp.Data;
using System.Runtime.InteropServices.Marshalling;

namespace BokningsApp
{
    public partial class InfoOmRum : ContentPage
    {
        private RoomInformation _roomInformation;
        public InfoOmRum()
        {
            InitializeComponent();
            _roomInformation = new RoomInformation();
            LoadRoomTypes();
            
        }

        //Hanterar val av rumstyp i första pickern
        private void OnRoomTypeSelected(object sender, EventArgs e)
        {
            var selectedRoomType = roomTypePicker.SelectedItem.ToString();
            LoadRoomsByType(selectedRoomType);

        }

        //laddar rummen baserat på vad man valt i första pickern
        private void LoadRoomsByType(string roomType)
        {
            var rooms = _roomInformation.GetRoomsByType(roomType);
            roomPicker.ItemsSource = rooms.Select(r => r.RoomName).ToList();
        }

        //Hanterar val i andra pickern
        private void OnRoomSelected(object sender, EventArgs e)
        {
            var selectedRoomName = roomPicker.SelectedItem.ToString();
            ShowRoomInfo(selectedRoomName);

        }

        //Visar informationen från det valda rummet
        private void ShowRoomInfo(string roomName)
        {
            var room = _roomInformation.GetRoomByName(roomName);
            if(room != null)
            {
                roomInfoLabel.Text = $"Rum: {room.RoomName} \nBeskrivning: {room.RoomDescription}\nPlatser: {room.Slots}";
            }
            else
            {
                roomInfoLabel.Text = "Finns ingen information för nuvarande";
            }
        }

        private void LoadRoomTypes()
        {
            var roomTypes = _roomInformation.GetAllRoomTypes();
            roomTypePicker.ItemsSource = roomTypes.Select(rt => rt.RoomType).ToList();
        }
    }
}
