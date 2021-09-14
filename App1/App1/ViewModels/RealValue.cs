using App1.Models;
using App1.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class RealValue
    {
        public ObservableCollection<Item> Items { get; }
        public async void GetRealValue(Item item)
        {
            var weatherService = DependencyService.Resolve<IWeatherService>();
            foreach (var Text in Items)
            {
                var weatherData = await weatherService.GetWeatherForCity(Text);
                Text.Temperature = weatherData.main.temp;
                Text.Pressure = weatherData.main.pressure;
                Text.Humidity = weatherData.main.humidity;
            }


        }
    }
}

