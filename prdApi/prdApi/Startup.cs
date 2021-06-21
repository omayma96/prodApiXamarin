using Microsoft.Extensions.DependencyInjection;
using prdApi.Services;
using prdApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace prdApi
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
          services.AddHttpClient<IProductService, ApiProductService>(c =>
            {
                c.BaseAddress = new Uri("http://10.0.2.2:57523/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

      

            //add viewmodels
            services.AddTransient<ProductsViewModel>();
            services.AddTransient<AddProductViewModel>();
            services.AddTransient<ProductDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
