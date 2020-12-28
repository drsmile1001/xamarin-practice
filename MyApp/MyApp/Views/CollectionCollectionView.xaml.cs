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
            BindingContext = new CollectionCollectionViewViewModel();
            InitializeComponent();
        }
    }
}