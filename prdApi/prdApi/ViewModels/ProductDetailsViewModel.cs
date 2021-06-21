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
    [QueryProperty(nameof(ProductId), nameof(ProductId))]
    public class ProductDetailsViewModel : BaseViewModel
    {
        private string productId;
        private string name;
        private string price;
        private string description;
        private readonly IProductService _productService;

        public ProductDetailsViewModel(IProductService productService)
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
                    Id = int.Parse(ProductId),
                    Name = Name,
                    Price = Price,
                    Description = Description
                };

                await _productService.SaveProduct(product);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadProduct(string productId)
        {
            try
            {
                var product = await _productService.GetProduct(int.Parse(productId));
                if (productId != null)
                {
                    Name = product.Name;
                    Price = product.Price;
                    Description = product.Description;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ProductId
        {
            get => productId;
            set
            {
                productId = value;
                LoadProduct(productId);
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
