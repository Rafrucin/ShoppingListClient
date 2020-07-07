using ShoppingListClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ShoppingListClient.Services
{
    public class Helpers : IHelpers
    {
        private readonly IProductServices _services;

        public Helpers(IProductServices services)
        {
            _services = services;
        }

        public async Task Finalise(List<ProductModel> products)
        {
            foreach (var product in products)
            {
                if (product.IsDone)
                {
                    product.Current = false;
                    product.Quantity = 0;
                    await _services.UpdateProduct(product);
                }
                
            }
        }

        public async Task AddProductAsync(ProductModel model, List<ProductModel> products, ProductModel selected)
        {
            if (model.Quantity<1)
            {
                model.Quantity = 1;
            }

            if (selected.Name!=null)
            {
                selected.Name = model.Name;
                selected.Quantity = model.Quantity;
                selected.Department = model.Department;
                await _services.UpdateProduct(selected);
                return;
            }

            if (products.Where(p => p.Name == model.Name).Count()>0 )
            {
                ProductModel p = products.Where(p => p.Name == model.Name).First();
                if (p.Current == false)
                {                
                    p.IsDone = false;
                    p.Current = true;
                    p.Quantity += model.Quantity;
                    await _services.UpdateProduct(p); 
                }
               else
                {
                    p.Quantity += model.Quantity;
                    await _services.UpdateProduct(p);
                }

            }            
            else
            {
                await _services.AddNewProduct(model);
            }
        }
    }
}
