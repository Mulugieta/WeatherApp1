using System;
using System.Drawing;
namespace App1.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Flag { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCurrentCity { get; set; }
        public double? Temperature { get; set; }
        public double? Pressure { get; set; }
        public double?Humidity { get; set; }
        public double? Wind { get; set; }
        public double?Clouds { get; set; }
        

    }
}