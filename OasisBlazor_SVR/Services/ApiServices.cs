using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OasisBlazor.Services;
using OasisBlazor_SVR.Models;

namespace OasisBlazor_SVR.Services
{
    public class ApiServices : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = "https://localhost:5001/api/";
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var content = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}identity/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResult = JsonSerializer.Deserialize<LoginResult>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return loginResult;
            }

            return new LoginResult { Successful = false };
        }

        public async Task Logout()
        {
            await _httpClient.PostAsync($"{_baseUrl}identity/logout", null);
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var content = new StringContent(JsonSerializer.Serialize(registerModel), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}identity/register", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var registerResult = JsonSerializer.Deserialize<RegisterResult>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return registerResult;
            }

            return new RegisterResult { Successful = false };
        }

        public async Task<Product[]> GetProducts()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}product");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<Product[]>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return products;
            }

            return new Product[] { };
        }

        public async Task<Product> GetProduct(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return product;
            }

            return null;
        }

        public async Task<bool> AddProduct(Product product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}product", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProduct(int id, Product product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}product/{id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}product/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
