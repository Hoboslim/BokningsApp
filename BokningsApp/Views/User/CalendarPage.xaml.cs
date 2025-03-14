using BokningsApp.Models;
using BokningsApp.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Globalization;

namespace BokningsApp.User;

public partial class CalendarPage : ContentPage
{

    public ObservableCollection<CalendarDay> Days { get; set; } = new();

    public string SelectedMonth { get; set; }

    private DateTime _currentMonth;
    
    public CalendarPage()
    {
        InitializeComponent();
        BindingContext = this;
        _currentMonth = DateTime.Now;
        GenerateCalendar(_currentMonth);


    }

    void GenerateCalendar(DateTime date)
    {
        Days.Clear();
        SelectedMonth = date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
        OnPropertyChanged(nameof(SelectedMonth));

        DateTime firstDay = new DateTime(date.Year, date.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

        int startDayOfWeek = ((int)firstDay.DayOfWeek + 6) % 7;

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


    private void OnPreviousMonthClicked(object sender, EventArgs e)
    {
        _currentMonth = _currentMonth.AddMonths(-1);
        GenerateCalendar(_currentMonth);

    }

    private void OnNextMonthClicked(object sender, EventArgs e)
    {
        _currentMonth = _currentMonth.AddMonths(1);
        GenerateCalendar(_currentMonth);
    }

    public class CalendarDay
    {
        public string? Day { get; set; }

    }

    private async void OnDateSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedDay = e.CurrentSelection[0] as CalendarDay;
            DateTime selectedDate = new DateTime(_currentMonth.Year, _currentMonth.Month, int.Parse(selectedDay.Day));

            await Navigation.PushAsync(new PickRoom(selectedDate.ToString("yyyy-MM-dd")));
        }
    }
}