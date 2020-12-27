using MyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DynamicData;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionCollectionView : ContentPage
    {
        public CollectionCollectionView()
        {
            InitializeComponent();
            var vm = new CollectionCollectionViewViewModel();
            BindingContext = vm;
            vm.AddOrUpdatePerson("Aclie", 23);
            vm.AddAge("Aclie", 1.5);
        }
    }
}