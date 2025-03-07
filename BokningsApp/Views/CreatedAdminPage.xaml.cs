namespace BokningsApp.Views;

public partial class CreatedAdminPage : ContentPage
{
	public CreatedAdminPage()
	{
		InitializeComponent();
	}

    private async void OnClickedBackToMain(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}