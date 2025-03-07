using BokningsApp.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Driver;

namespace BokningsApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public Models.User Users { get; set; }
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

            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            var filter = Builders<Models.User>.Filter.Eq(x => x.Email, Users.Email);
            var user = await Data.DB.GetUserCollection().Find(filter).FirstOrDefaultAsync();

            if (user != null && user.Password == password)
            {
                if (user.Role == "Admin")
                {
                    await Navigation.PushAsync(new AdminLoggedIn());
                }
                else if (user.Role == "User")
                {
                    await Navigation.PushAsync(new InLoggad());
                }
            }

        }

        //private async void OnAdminPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AdminLoggedIn());
        //}
    }

}
