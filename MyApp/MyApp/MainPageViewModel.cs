using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp
{
    public class MainPageViewModel : ReactiveObject
    {
        public MainPageViewModel()
        {
            Add = ReactiveCommand.Create(() => 
            {
                Count += 1;
            });
        }

        private int _count;

        public int Count
        {
            get => _count;
            set => this.RaiseAndSetIfChanged(ref _count, value);
        }

        public ReactiveCommand<Unit, Unit> Add { get; }
    }
}
