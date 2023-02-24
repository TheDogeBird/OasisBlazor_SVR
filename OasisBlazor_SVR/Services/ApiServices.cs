using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace OasisBlazor_SVR.Services
{
    public class ApiServices : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task Register(string email, string password, string firstName, string lastName, int age, string country, string gender, string username)
        {
            var requestUrl = _configuration.GetValue<string>("ApiBaseUrl") + "api/account/register";

            var requestBody = new
            {
                email = email,
                password = password,
                firstName = firstName,
                lastName = lastName,
                age = age,
                country = country,
                gender = gender,
                username = username
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUrl, data);

            response.EnsureSuccessStatusCode();
        }
    }
}
