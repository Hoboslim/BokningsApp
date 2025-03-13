namespace BokningsApp;

public partial class CreatedAccountPage : ContentPage
{
	public CreatedAccountPage()
	{
		InitializeComponent();
	}

    private async void OnClickedBackToMain(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}