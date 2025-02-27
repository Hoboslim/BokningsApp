namespace BokningsApp.User;

public partial class Calendar : ContentPage
{
	public Calendar()
	{
		InitializeComponent();
	}

    private async void OnDateSelected(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new PickRoom());
    }
}