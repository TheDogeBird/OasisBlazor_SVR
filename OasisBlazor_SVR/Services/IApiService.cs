using System.Collections.Generic;
using System.Threading.Tasks;
using OasisBlazor.Models;

namespace OasisBlazor.Services
{
    public interface IApiService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> DeleteProduct(int id);
    }
}
