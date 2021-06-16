using prdApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace prdApi.Services
{
    class ApiProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ApiProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync("Products");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Product>>(responseAsString);
        }

        public async Task<Product> GetProduct(int id)
        {
            var response = await _httpClient.GetAsync($"Product/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(responseAsString);
        }

        public async Task AddProduct(Product product)
        {
            var response = await _httpClient.PostAsync("Products",
                new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }



        public async Task SaveProduct(Product product)
        {
            var response = await _httpClient.PutAsync($"Products?id={product.Id}",
                new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(Product product)
        {
            var response = await _httpClient.DeleteAsync($"Products/{product.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
