using MyApp.ViewModels;

namespace MyApp.Views
{
    public partial class Counter
    {
        public Counter()
        {
            BindingContext = new CounterViewModel();
            InitializeComponent();
        }
    }
}
