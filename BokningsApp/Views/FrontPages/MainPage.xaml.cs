using BokningsApp.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Driver;
using System.Linq.Expressions;

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

            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error,", "Please enter both email and passsword!.", "OK");
                return;
            }
            try
            {

                var filter = Builders<Models.User>.Filter.Eq(x => x.Email, email);
                var user = await Data.DB.GetUserCollection().Find(filter).FirstOrDefaultAsync();

                if (user == null || user.Password != password)
                {
                    await DisplayAlert("Login Failed", "Invalid email or password", "OK");
                    return;
                }
                
                if (user != null && user.Password == password)
                {

                    await SecureStorage.SetAsync("user_id", user.Id.ToString());

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
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An unexpected error occured. Please try again", "OK");
                return;
            }

        }

        //private async void OnAdminPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AdminLoggedIn());
        //}
    }
}

