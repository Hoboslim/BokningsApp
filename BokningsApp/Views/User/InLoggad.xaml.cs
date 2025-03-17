using BokningsApp.Views.User;
using MongoDB.Bson;
using BokningsApp.Models;

namespace BokningsApp;

public partial class InLoggad : ContentPage
{
    public InLoggad()
    {
        InitializeComponent(); 
    }
    private async void OnBokaRum(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new User.CalendarPage());
    }
    private async void OnInfoOmRum(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoOmRum());
    }
  
    private async void OnSeMinaBokade(object sender, EventArgs e)
    {
        var loggedInUserId = GetLoggedInUserId();
        await Navigation.PushAsync(new MyBookings(loggedInUserId));
    }



    private ObjectId GetLoggedInUserId()
    {
        var userIdString = Preferences.Get("LoggedInUserId", "");
        return string.IsNullOrEmpty(userIdString) ? ObjectId.Empty : new ObjectId(userIdString);
    }
}