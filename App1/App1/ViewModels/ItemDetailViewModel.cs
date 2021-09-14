using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public Command LoadItemsCommand2 { get; }
        private string itemId;
        private string text;
        private string description;
        private string country;
        private string flag;
        private string imageUrl;
        private double? temperature;
        private double? pressure;
        private double? humidity;
        private double? wind;
        private double? clouds;
      
        public string Id { get; set; }
        public ItemDetailViewModel()
        {
            LoadItemsCommand2 = new Command<string>(LoadItemId);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public string Flag
        {
            get => flag;
            set => SetProperty(ref flag, value);
        }
        public string ImageUrl
        {
            get => imageUrl;
            set => SetProperty(ref imageUrl, value);
        }
       
        public double? Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }
        public double? Pressure
        {
            get => pressure;
            set => SetProperty(ref pressure, value);
        }
        public double? Clouds
        {
            get => clouds;
            set => SetProperty(ref clouds, value);
        }
        public double? Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }
        public double? Wind
        {
            get => wind;
            set => SetProperty(ref wind, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        private async void LoadItemId(string itemId)
        {
            try
            {
                IsBusy = true;
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Country = item.Country;
                ImageUrl = item.ImageUrl;
                Temperature = item.Temperature;
                Pressure = item.Pressure;
                Humidity = item.Humidity;
                Wind = item.Wind;
                Clouds = item.Clouds;
                Flag = item.Flag;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
