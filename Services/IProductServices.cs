using ShoppingListClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListClient.Services
{
    public interface IProductServices
    {
        Task<List<ProductModel>> GetAllProducts();
        public Task<ProductModel> AddNewProduct(ProductModel model);
        public Task UpdateProduct(ProductModel model);
    }
}