using System.Collections.ObjectModel;
using System.Globalization;

namespace BokningsApp.User;

public partial class CalendarPage : ContentPage
{

    public ObservableCollection<CalendarDay> Days { get; set; } = new();
    public string SelectedMonth { get; set; }
    public CalendarPage()
    {
        InitializeComponent();
        BindingContext = this;
        GenerateCalendar(DateTime.Now);
    }

    void GenerateCalendar(DateTime date)
    {
        Days.Clear();
        SelectedMonth = date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
        OnPropertyChanged(nameof(SelectedMonth));

        DateTime firstDay = new DateTime(date.Year, date.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        
       int startDayOfWeek = ((int)firstDay.DayOfWeek + 6 ) % 7;

        for (int i = 0; i < startDayOfWeek; i++)
        {
            Days.Add(new CalendarDay { Day = "" });
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Days.Add(new CalendarDay { Day = day.ToString() });

        }
        OnPropertyChanged(nameof(Days));

    }

    public class CalendarDay
    {
        public string Day { get; set; }

    }


    private async void OnDateSelected(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PickRoom());
    }
}