using BokningsApp.Admin;

namespace BokningsApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(null));
        }

        private async void OnButtonLoggin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InLoggad());
        }

        private async void OnAdminPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminLoggedIn());
        }
    }

}
