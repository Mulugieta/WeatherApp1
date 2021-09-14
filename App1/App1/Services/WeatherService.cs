using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherForCity(Item item);
        
    }
    public class WeatherService : IWeatherService
    {
        private const string WeatherApiKey = "7523bb344444d436cf140404f1f7be9f";
        private const string Units = "metric";
        private const string CurrentWeatherApiEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        private const string CurrentIconUrl = "http://openweathermap.org/img/w/";
        private const string png = ".png";
        public async Task<WeatherData> GetWeatherForCity(Item item)
        {
            var cityWeatherUrl = $"{CurrentWeatherApiEndpoint}?q={item.Text}&units={Units}&appid={WeatherApiKey}";
            var httpClient = new HttpClient();
            var weatherResponse = await httpClient.GetStringAsync(cityWeatherUrl);
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(weatherResponse);
            
            return weatherData;
        } 
    }
}
