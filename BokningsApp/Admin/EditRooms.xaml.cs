namespace BokningsApp.Admin;

public partial class EditRooms : ContentPage
{
    private Dictionary<string, List<string>> roomData = new Dictionary<string, List<string>>()
    {
        { "Rum med TV", new List<string> { "Fusion", "Horizon", "Pinnacle" } },
        { "Rum med SmartBoard", new List<string> { "Synergy", "Nexus", "Elevate" } },
        { "Uterum", new List<string> { "Vertex", "Momentum", "Pinnacle" } }
    };

    public EditRooms()
    {
        InitializeComponent();
    }

    private void OnRoomTypeSelected(object sender, EventArgs e)
    {
        if (roomTypePicker.SelectedItem is string selectedType && roomData.ContainsKey(selectedType))
        {
            roomPicker.Items.Clear();
            foreach (var room in roomData[selectedType])
            {   
                roomPicker.Items.Add(room);
            }
            roomPicker.SelectedIndex = -1; 
          
        }
    }
    private async void OnEditRoomClicked(object sender, EventArgs e)
    {
        if (roomPicker.SelectedItem is string selectedRoom && !string.IsNullOrEmpty(selectedRoom))
        {
           // var editPage = new EditRoomDetails(selectedRoom);
            //await Navigation.PushAsync(editPage);
        }
        else
        {
            await DisplayAlert("Fel", "Välj ett rum först!", "OK");
        }
    }
}
