using BokningsApp.ViewModels;

namespace BokningsApp.User;

public partial class PickRoom : ContentPage
{
	public PickRoomViewModel ViewModel {  get; set; }
	public PickRoom()
	{
		InitializeComponent();

		ViewModel = new PickRoomViewModel();

		BindingContext = ViewModel;
	}
}