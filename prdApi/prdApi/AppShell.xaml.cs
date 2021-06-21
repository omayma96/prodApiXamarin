using prdApi.ViewModels;
using prdApi.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace prdApi
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddProduct), typeof(AddProduct));
            Routing.RegisterRoute(nameof(ProductDetails), typeof(ProductDetails));
        }

    }
}
