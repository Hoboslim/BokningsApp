namespace BokningsApp.Admin;

public partial class AdminLoggedIn : ContentPage
{
	public AdminLoggedIn()
	{
		InitializeComponent();
	}

    private async void OnOldBookings(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingHistory());
    }

    private async void OnBokedRooms(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookedRooms());
    }

    private async void OnEditRooms(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditRooms());
    }

    private async void OnAddRoom(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoom());
    }
}