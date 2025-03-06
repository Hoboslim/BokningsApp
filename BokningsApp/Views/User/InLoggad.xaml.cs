using BokningsApp.User;
using System.Globalization;

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

    private void OnAvbokaRum(object sender, EventArgs e)
    {
    
    }

    private void OnSeMinaBokade(object sender, EventArgs e)
    {
   
    }
}
