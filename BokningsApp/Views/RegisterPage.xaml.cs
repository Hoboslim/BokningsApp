namespace BokningsApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void OnCreatedAccount(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CreatedAccountPage());
    }
}