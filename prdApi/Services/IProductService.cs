using prdApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prdApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task SaveProduct(Product product);
        Task DeleteProduct(Product product);
    }
}