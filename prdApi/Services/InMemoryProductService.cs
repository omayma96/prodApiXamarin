using prdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prdApi.Services
{
    class InMemoryProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        public InMemoryProductService()
        {
            _products.Add(new Product { Id = 1, Name = "Clean code", Price = "100", Description = "A book about good code" });
            _products.Add(new Product { Id = 2, Name = "The pragmatic programmer", Price = "200", Description = "All about pragmatism" });
            _products.Add(new Product { Id = 3, Name = "Refactoring", Price = "300", Description = "Working with legacy code" });
        }
        public Task AddProduct(Product product)
        {
            product.Id = ++_products.Last().Id;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(Product product)
        {
            _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task<Product> GetProduct(int id)
        {
            var product = _products.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task SaveProduct(Product product)
        {
            _products[_products.FindIndex(b => b.Id == product.Id)] = product;
            return Task.CompletedTask;
        }
    }
}
