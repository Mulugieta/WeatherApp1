using App1.Models;
using App1.Services;
using App1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;

namespace App1.ViewModels
{
    public partial class ItemsViewModel : BaseViewModel
    {
       
        private Item _selectedItem;
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }
        public Command<Item> ItemAppeared { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
           
        }
       
     
        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                IsBusy = true;
                var weatherService = DependencyService.Resolve<IWeatherService>();
                foreach (var Text in Items)
                {
                    var weatherData = await weatherService.GetWeatherForCity(Text);
                    Text.Temperature = Math.Round(weatherData.main.temp, 2);
                    Text.Pressure = weatherData.main.pressure;
                    Text.Humidity = weatherData.main.humidity;
                    Text.Description = weatherData.weather[0].description;
                    Text.Country = weatherData.sys.country;
                    Text.Wind = Math.Round(weatherData.wind.speed , 1);
                    Text.Clouds = weatherData.clouds.all;

                    //Code For Fetching Country Flag
                    var CountryName = weatherData.sys.country.ToString();
                    var lastCountryName = CountryName;
                    Text.Flag = "https://www.countryflags.io/" + lastCountryName + "/shiny/64.png";

                    //Code  For Fetching Icon Of Current Weather
                    var iconCode = weatherData.weather[0].icon;
                    var iconcode2 = iconCode;
                    Text.ImageUrl = "http://openweathermap.org/img/w/" + iconcode2 + ".png";
                
                }

                Items.Clear();

                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;

            }
       
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        public  void OnItemSelected(Item item)
        {
            if (item == null)
                return;
           
            // This will push the ItemDetailPage onto the navigation stack
            DependencyService.Resolve<INavigationService>().GoToItemDetailPage(item);
           
        }


        }
    public class CityDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate CurrentTemplate { get; set; }
        public CityDataTemplateSelector()
        {/* DefaultTemplate = new DataTemplate(typeof(TextCell)); CurrentTemplate = new DataTemplate(typeof(ImageCell));*/ }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var city = item as Item;
            return city.IsCurrentCity ? CurrentTemplate : DefaultTemplate;
            
        }
        
    }
}

