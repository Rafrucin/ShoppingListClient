using ShoppingListClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingListClient.Services
{
    public interface IHelpers
    {
        Task AddProductAsync(ProductModel model, List<ProductModel> products, ProductModel selected);
        Task Finalise(List<ProductModel> products);
    }
}