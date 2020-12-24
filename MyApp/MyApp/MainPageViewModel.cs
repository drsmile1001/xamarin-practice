using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            Add = new Command(() =>
            {
                Count += 1;
            });
        }

        private int _count;

        public int Count
        {
            get => _count;
            set {
                if (value == _count) return;
                _count = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public ICommand Add { get; }
    }
}
