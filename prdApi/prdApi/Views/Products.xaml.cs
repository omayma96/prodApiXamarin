using prdApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prdApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        private readonly ProductsViewModel _productsViewModel;
        public Products()
        {
            InitializeComponent();
            _productsViewModel = Startup.Resolve<ProductsViewModel>();
            BindingContext = _productsViewModel;
        }
        protected override void OnAppearing()
        {
            _productsViewModel?.PopulateProducts();
        }
    }
}