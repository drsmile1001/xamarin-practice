using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionCollectionView : ContentPage
    {
        public class ValueModel
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

        public CollectionCollectionView()
        {
            InitializeComponent();
            BindingContext = new
            {

                Items = Enumerable.Range(0, 100).Select(i => new ValueModel
                {
                    Name = Guid.NewGuid().ToString(),
                    Age = i
                }).ToArray()
            };
        }
    }
}