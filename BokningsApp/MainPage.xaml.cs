namespace BokningsApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonLoggin(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InLoggad());
        }
    }

}
