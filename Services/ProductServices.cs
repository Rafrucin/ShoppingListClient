using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using ShoppingListClient.Models;
using System.Globalization;

namespace ShoppingListClient.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL = "https://rafsshoppingapi.azurewebsites.net/api/ProductModels";
        //private readonly string _baseURL = "https://localhost:44337/api/productmodels";


        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>(_baseURL);
        }

        public async Task<ProductModel> AddNewProduct(ProductModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseURL, model);
            return await response.Content.ReadFromJsonAsync<ProductModel>();
        }

        public async Task UpdateProduct(ProductModel model)
        {
            var response = await _httpClient.PutAsJsonAsync<ProductModel>($"{_baseURL}/{model.Id}", model);            
        }


    }
}
