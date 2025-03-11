using BokningsApp.Views;
using MongoDB.Bson;

namespace BokningsApp.Admin;

public partial class AddRoomType : ContentPage
{
	public Models.RoomTypes RoomTypes { get; set; }
    public AddRoomType(Models.RoomTypes roomTypes)
	{
		InitializeComponent();
        RoomTypes = roomTypes;

        if (roomTypes != null)
        {
            RoomTypeNameEntry.Text = roomTypes.RoomType;
        }
    }

    private async void OnAddRoomType(object sender, EventArgs e)
    {
        if (RoomTypes == null)
        {
            RoomTypes = new Models.RoomTypes
            {
                Id = ObjectId.GenerateNewId(),
                RoomType = RoomTypeNameEntry.Text,
            };
            await Data.DB.GetRoomTypesCollection().InsertOneAsync(RoomTypes);
        }
        else
        {
            await Data.DB.GetRoomTypesCollection().InsertOneAsync(RoomTypes);
        }
        await Navigation.PushAsync(new Admin.AdminLoggedIn());
    }
}