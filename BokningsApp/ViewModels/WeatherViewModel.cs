using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BokningsApp.Models;

namespace BokningsApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Weather _weather;
        public Weather Weather
        {
            get => _weather;
            set
            {
                _weather = value;
                OnPropertyChanged(nameof(Weather));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task GetWeatherAsync(double latitude, double longitude)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.api-ninjas.com/");
                client.DefaultRequestHeaders.Add("X-Api-Key", "jrAKIKlyeSQaWmsl7/tnaw==oGypKlV0gz1Foi1S");

                HttpResponseMessage response = await client.GetAsync($"v1/weather?lat={latitude}&lon={longitude}");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    var weatherData = JsonSerializer.Deserialize<Weather>(responseString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (weatherData != null)
                    {
                        Weather = weatherData;
                        OnPropertyChanged(nameof(Weather));
                    }
                }
            }
            catch (Exception)
            {
              
            }
        }
    }
}
