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
            RoomTypeEntry.Text = room.RoomType;
            RoomDescriptionEntry.Text = room.RoomDescription;
            SlotsEntry.Text = room.Slots.ToString();
        }
    }

    private void OnEditRoomsDone(object sender, EventArgs e)
    {
        Models.Rooms room = new Models.Rooms
        {
            Id = ObjectId.GenerateNewId(),
            RoomName = RoomNameEntry.Text,
            RoomType = RoomTypeEntry.Text,
            RoomDescription = RoomDescriptionEntry.Text,
            Slots = int.Parse(SlotsEntry.Text),
        };
        Data.DB.GetRoomCollection().InsertOne(room);
        Navigation.PushAsync(new AdminLoggedIn());

    }
}