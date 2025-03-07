using BokningsApp.Views.User;

namespace BokningsApp;

public partial class InLoggad : ContentPage
{
    public InLoggad()
    {
        InitializeComponent(); 
    }
    

    private void OnBokaRum(object sender, EventArgs e)
    {
    
    }

    private async void OnInfoOmRum(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoOmRum());
    }

    private async void OnAvbokaRum(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CancelRoom());
    }

    private async void OnSeMinaBokade(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyBookings());
    }
}
