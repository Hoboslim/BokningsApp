using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BokningsApp.ViewModels
{
    internal class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Models.Weather _weather;
        public Models.Weather Weather
        {
            get { return _weather; }
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

        // ✅ Hämta väderdata
        public async Task GetWeatherAsync(double latitude, double longitude)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.api-ninjas.com/");
                client.DefaultRequestHeaders.Add("X-Api-Key", "jrAKIKlyeSQaWmsl7/tnaw==oGypKlV0gz1Foi1S");

                Debug.WriteLine("🔍 Anropar API för väderdata..."); // ✅ Debug-logg

                HttpResponseMessage response = await client.GetAsync($"v1/weather?lat={latitude}&lon={longitude}");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Weather = JsonSerializer.Deserialize<Models.Weather>(responseString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    Debug.WriteLine($"✅ Väderdata hämtad: Temperatur: {Weather?.temp}°C");
                    OnPropertyChanged(nameof(Weather)); // 🔄 Uppdaterar UI
                }
                else
                {
                    Debug.WriteLine($"❌ Fel vid API-anrop: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"🚨 Fel vid hämtning av väderdata: {ex.Message}");
            }
        }
    }
}
