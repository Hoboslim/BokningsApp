using BokningsApp.ViewModels;

namespace BokningsApp.User;

public partial class PickRoom : ContentPage
{
	private BookingViewModel _ViewModel;
	public PickRoom(string selectedDate)
	{
		InitializeComponent();
		_ViewModel = new BookingViewModel(selectedDate);
		BindingContext = _ViewModel;
	}

    private async void OnBookClicked(object sender, EventArgs e)
    {
		if (_ViewModel.SelectedRoom != null && _ViewModel.SelectedTime != null)
		{
			await DisplayAlert("Klart!", "Rummet har blivit bokat", "OK");
		}
		else
		{
			await DisplayAlert("Felaktig inmatning", "Välj ett rum och en tid", "OK");
		}
    }
}