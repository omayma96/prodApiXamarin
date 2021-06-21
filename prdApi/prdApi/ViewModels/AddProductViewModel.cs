using prdApi.Models;
using prdApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace prdApi.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        private readonly IProductService _productService;
        private string name;
        private string price;
        private string description;

        public AddProductViewModel(IProductService productService)
        {
            _productService = productService;

            SaveProductCommand = new Command(async () => await SaveProduct());
        }

        private async Task SaveProduct()
        {
            try
            {
                var product = new Product
                {
                    Name = Name,
                    Price = Price,
                    Description = Description
                };

                await _productService.AddProduct(product);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        public ICommand SaveProductCommand { get; }
    }
}
