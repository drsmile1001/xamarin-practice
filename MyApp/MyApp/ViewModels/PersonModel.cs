using ReactiveUI;

namespace MyApp.ViewModels
{
    public class PersonModel : ReactiveObject
    {
        public string ID { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
    }
}
