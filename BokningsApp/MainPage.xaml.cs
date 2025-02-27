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
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnButtonLoggin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InLoggad());
        }
    }

}
