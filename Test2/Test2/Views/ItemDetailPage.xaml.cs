using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Test2.Models;
using Test2.ViewModels;
using Test2.Services;
using System.Threading.Tasks;

namespace Test2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;
        private RestService service;

        public Item Item { get; set; }
        public WeatherObject Weather { get; set; }

        public ItemDetailPage(Item item)
        {
            service = new RestService();
            InitializeComponent();
            getWeather(item);
            Item = item;
            viewModel = new ItemDetailViewModel(Item, Weather);
            BindingContext = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            Item = new Item
            {
                City = "Gdańsk",
                CountryCode = "PL"
            };

            viewModel = new ItemDetailViewModel(Item, null);
            BindingContext = viewModel;
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteItem", Item);
            await Navigation.PopAsync();
        }


        async void getWeather(Item item)
        {
            Weather = await service.GetResponse(item.City, item.CountryCode);

            if (Weather.Wind.Speed <= 1.5)
            {
                viewModel.Drop = "approved.";
            }

            viewModel.WeatherObject = Weather;
        }
    }
}