using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class CounterViewModel : ReactiveObject
    {
        public CounterViewModel()
        {
            Add = ReactiveCommand.Create(() =>
            {
                Count += 1;
            });

            _doubleValue = this.WhenAnyValue(vm => vm.Count)
                .Select(count => count * 2)
                .ToProperty(this, nameof(DoubleValue));
        }

        private int _count;

        public int Count
        {
            get => _count;
            set => this.RaiseAndSetIfChanged(ref _count, value);
        }

        readonly ObservableAsPropertyHelper<int> _doubleValue;
        public int DoubleValue => _doubleValue.Value;

        public ReactiveCommand<Unit, Unit> Add { get; }
    }
}
