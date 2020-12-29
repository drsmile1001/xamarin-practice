using System;
using Xamarin.Forms;
using ReactiveUI;


namespace MyApp.Views
{
    public class NoXamlTest : ContentPage
    {
        public class State : ReactiveObject
        {
            private int _count;
            public int Count
            {
                get => _count;
                set => this.RaiseAndSetIfChanged(ref _count, value);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var state = new State();

            var counterLabel = new Label { Text = $"Clicked 0 times！" };
            state.WhenAnyValue(s => s.Count)
                .Subscribe(count =>
                {
                    counterLabel.Text = $"Clicked {count} times！";
                });

            var addButton = new Button
            {
                Text = "Add",
                Command = new Command(() =>
                {
                    state.Count += 2;
                })
            };

            Content = new StackLayout
            {
                Children = {
                    counterLabel,
                    addButton
                }
            };
        }
    }
}