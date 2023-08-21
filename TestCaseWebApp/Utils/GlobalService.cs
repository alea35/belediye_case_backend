using CaseEntity;
using Newtonsoft.Json;
using System.Text;
using TestCaseWebApp.Models;

namespace TestCaseWebApp.Utils
{
    public class GlobalService
    {
        HttpClient client;
        public GlobalService(HttpClient _client)
        {
                client = _client;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var response = await client.GetAsync($"Product/GetAll?");
            string context = await response.Content.ReadAsStringAsync();

           var products = JsonConvert.DeserializeObject<List<Product>>(context);
            return products;
        }

        

        public async Task<Product> GetProductById(Guid id)
        {
            var response = await client.GetAsync($"Product/GetById?id={id.ToString()}");
            string context = await response.Content.ReadAsStringAsync();
            Product product = new Product();
            product = JsonConvert.DeserializeObject<Product>(context);

            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var response = await client.GetAsync($"Product/Delete?id={id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Product>> FilterProducts(string sortOrder,string category)
        {
            var response = await client.GetAsync($"Product/Filter?sortOrder={sortOrder}&category={category}");
            string context = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(context);
            return products;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            
            var content = JsonConvert.SerializeObject(product);
            var response = await client.PostAsync($"Product/Update?", new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            var content = JsonConvert.SerializeObject(product);
            var response = await client.PostAsync($"Product/Create?", new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            var categoryResponse = await client.GetAsync($"Category/GetAll");

            string categoryContext = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoryContext);
            return categories;
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            var response = await client.GetAsync($"Category/GetById?id={id.ToString()}");
            string context = await response.Content.ReadAsStringAsync();
            Category category = new Category();
            category = JsonConvert.DeserializeObject<Category>(context);

            return category;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var response = await client.GetAsync($"Category/Delete?id={id}");

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateCategory(Category category)
        {

            var content = JsonConvert.SerializeObject(category);
            var response = await client.PostAsync($"Category/Update?", new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateCategory(Category category)
        {
            var content = JsonConvert.SerializeObject(category);
            var response = await client.PostAsync($"Category/Create?", new StringContent(content, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }

}
