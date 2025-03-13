using MongoDB.Bson;
using MongoDB.Driver;

namespace BokningsApp;

public partial class RegisterPage : ContentPage
{
    public Models.User Users { get; set; }


    public RegisterPage(Models.User users)
    {
        InitializeComponent();
        Users = users;
        if (users != null)
        {
            FirstNameEntry.Text = users.Firstname;
            LastNameEntry.Text = users.Lastname;
            EmailEntry.Text = users.Email;
            PasswordEntry.Text = users.Password;

        }
    }
    private async void OnCreatedAccount(object sender, EventArgs e)
    {
        
            Models.User user = new Models.User
            {
                Id = ObjectId.GenerateNewId(),
                Firstname = FirstNameEntry.Text,
                Lastname = LastNameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text,
                Role = "User",
            };
            await Data.DB.GetUserCollection().InsertOneAsync(user);
            await Navigation.PushAsync(new CreatedAccountPage());
    }

    private async void OnCreatedAccountAdmin(object sender, EventArgs e)
    {
        Models.User user = new Models.User
        {
            Id = ObjectId.GenerateNewId(),
            Firstname = FirstNameEntry.Text,
            Lastname = LastNameEntry.Text,
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text,
            Role = "Admin",
        };
        await Data.DB.GetUserCollection().InsertOneAsync(user);
        await Navigation.PushAsync(new Views.CreatedAdminPage());
    }
}