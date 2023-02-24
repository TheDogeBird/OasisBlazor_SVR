using OasisBlazor_SVR.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OasisBlazor_SVR.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync()
        {
            var response = await _httpClient.GetAsync("https://your-api.com/userprofiles");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var userProfiles = JsonSerializer.Deserialize<IEnumerable<UserProfile>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return userProfiles;
            }

            throw new Exception("Failed to get user profiles");
        }

        public async Task<UserProfile> GetUserProfileAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://your-api.com/userprofiles/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var userProfile = JsonSerializer.Deserialize<UserProfile>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return userProfile;
            }

            throw new Exception("Failed to get user profile");
        }

        public async Task<UserProfile> CreateUserAsync(UserProfile userProfile)
        {
            var userProfileJson = JsonSerializer.Serialize(userProfile);
            var content = new StringContent(userProfileJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://your-api.com/userprofiles", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdUserProfile = JsonSerializer.Deserialize<UserProfile>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return createdUserProfile;
            }

            throw new Exception("Failed to create user profile");
        }

        public async Task<UserProfile> UpdateUserProfileAsync(int id, UserProfile userProfile)
        {
            var userProfileJson = JsonSerializer.Serialize(userProfile);
            var content = new StringContent(userProfileJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://your-api.com/userprofiles/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedUserProfile = JsonSerializer.Deserialize<UserProfile>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return updatedUserProfile;
            }

            throw new Exception("Failed to update user profile");
        }

        public async Task DeleteUserProfileAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://your-api.com/userprofiles/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete user profile");
            }
        }
    }
}
