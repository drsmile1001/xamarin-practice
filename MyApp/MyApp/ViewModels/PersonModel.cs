using ReactiveUI;

namespace MyApp.ViewModels
{
    public class PersonModel : ReactiveObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        private double _age;
        public double Age
        {
            get => _age;
            set => this.RaiseAndSetIfChanged(ref _age, value);
        }
    }
}
