namespace BokningsApp.User;

public partial class ThankYouPage : ContentPage
{
	public ThankYouPage()
	{
		InitializeComponent();
	}

    private async void OnToInloggedPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//inloggad");
    }
}