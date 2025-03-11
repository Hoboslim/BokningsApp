using BokningsApp.Models;
using BokningsApp.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BokningsApp.Admin;


public partial class EditRoomDetails : ContentPage
{
    public PickRoomViewModel ViewModel { get; set; }
    public Models.Rooms Room { get; set; }

    public EditRoomDetails(Models.Rooms room)
    {

        InitializeComponent();
        Room = room;
        ViewModel = new PickRoomViewModel();
        BindingContext = ViewModel;

        if (room != null)
        {
            RoomNameEntry.Text = room.RoomName;
            RoomDescriptionEntry.Text = room.RoomDescription;
            SlotsEntry.Text = room.Slots.ToString();
        }
    }
    private async void OnAddRoomsDone(object sender, EventArgs e)
    {
        if (Room == null)
        {
            Models.Rooms room = new Models.Rooms
            {
                RoomName = RoomNameEntry.Text,
                RoomDescription = RoomDescriptionEntry.Text,
                Slots = int.Parse(SlotsEntry.Text),
            };
            
            await Data.DB.GetRoomCollection().InsertOneAsync(room);

        }
        else
        {
            Room.RoomName = RoomNameEntry.Text;
            Room.RoomDescription = RoomDescriptionEntry.Text;
            Room.Slots = int.Parse(SlotsEntry.Text);
            var filter = Builders<Models.Rooms>.Filter.Eq(p => p.Id, Room.Id);
            await Data.DB.GetRoomCollection().ReplaceOneAsync(filter, Room);
        }
        await Navigation.PushAsync(new AdminLoggedIn());

    }
}