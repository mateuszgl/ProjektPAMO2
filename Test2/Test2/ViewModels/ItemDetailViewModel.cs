using System;
using System.ComponentModel;
using Test2.Models;

namespace Test2.ViewModels
{
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public String Title { get; set; }
        public Item Item { get; set; }

        private WeatherObject _weatherObject;
        private String _drop;

        public WeatherObject WeatherObject {
            get
            {
                return _weatherObject;
            }
            set
            {
                _weatherObject = value;
                NotifyPropertyChanged("WeatherObject");
            }
        }
        public String Drop
        {
            get
            {
                return _drop;
            }
            set
            {
                _drop = value;
                NotifyPropertyChanged("Drop");
            }
        }
        public ItemDetailViewModel(Item item = null, WeatherObject weather = null)
        {
            Title = item?.City;
            Item = item;
            WeatherObject = weather;
            Drop = "not recommended!";
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
