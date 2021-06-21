using prdApi.Models;
using prdApi.Services;
using prdApi.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace prdApi.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private readonly IProductService _productService;

        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;

            Products = new ObservableCollection<Product>();

            DeleteProductCommand = new Command<Product>(async b => await DeleteProduct(b));

            AddNewProductCommand = new Command(async () => await GoToAddproductView());
        }

        private async Task DeleteProduct(Product b)
        {
            await _productService.DeleteProduct(b);

            PopulateProducts();
        }

        private async Task GoToAddproductView()
            => await Shell.Current.GoToAsync(nameof(AddProduct));

        public async void PopulateProducts()
        {
            try
            {
                Products.Clear();

                var products = await _productService.GetProducts();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void OnBookSelected(Product product)
        {
            if (product == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ProductDetails)}?{nameof(ProductDetailsViewModel.ProductId)}={product.Id}");
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;

                    OnBookSelected(SelectedProduct);
                }
            }
        }

        public ICommand DeleteProductCommand { get; }

        public ICommand AddNewProductCommand { get; }
    }
}
