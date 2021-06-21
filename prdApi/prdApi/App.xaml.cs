using prdApi.Services;
using prdApi.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prdApi
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.ConfigureServices();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
