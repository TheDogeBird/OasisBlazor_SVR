using System.Collections.Generic;
using System.Threading.Tasks;
using OasisBlazor_SVR.Areas.Identity.Pages;
using OasisBlazor.Models;

namespace OasisBlazor.Services
{
    public interface IApiService
    {
        // Authentication
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<LoginResult> Register(RegisterModel registerModel);

        // Products
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
    }
}
