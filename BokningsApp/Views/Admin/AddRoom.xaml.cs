using MongoDB.Bson;

namespace BokningsApp.Admin;

public partial class AddRoom : ContentPage
{
    public Models.Rooms Room { get; set; }
    public AddRoom(Models.Rooms room)
    {
        
		InitializeComponent();
        Room = room;
        if (room != null)
        {
            RoomNameEntry.Text = room.RoomName;
            PickerEntry.SelectedItem = room.RoomType;
            RoomDescriptionEntry.Text = room.RoomDescription;
            SlotsEntry.Text = room.Slots.ToString();
        }
    }
    private async void OnAddRoomsDone(object sender, EventArgs e)
{
    if (Room != null)
    {
        Models.Rooms room = new Models.Rooms
        {
            Id = ObjectId.GenerateNewId(),
            RoomName = RoomNameEntry.Text,
            // RoomType = (Models.RoomType)PickerEntry.SelectedItem,
            RoomDescription = RoomDescriptionEntry.Text,
            Slots = int.Parse(SlotsEntry.Text),
        };

        await Data.DB.GetRoomCollection().InsertOneAsync(room);
        Navigation.PushAsync(new AdminLoggedIn());
    }

}
}