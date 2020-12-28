using MyApp.Models;
using ReactiveUI;
using ReactiveUI.XamForms;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonView : ReactiveContentView<PersonModel>
    {
        public PersonView()
        {
            InitializeComponent();
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, vm => vm.ID, v => v.TheIDLabel.Text)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, vm => vm.Name, v => v.TheNameLabel.Text)
                    .DisposeWith(disposable);
            });
        }
    }
}