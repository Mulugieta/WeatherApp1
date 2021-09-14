using App1.Services;
using App1.ViewModels;
using App1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static App1.ViewModels.ItemsViewModel;

namespace App1
{
    public partial class App : Application
    {
        ItemsViewModel _viewModel1;
        public App()
        {
            InitializeComponent();
            BindingContext = _viewModel1 = new ItemsViewModel();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IWeatherService, WeatherService>();


            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
