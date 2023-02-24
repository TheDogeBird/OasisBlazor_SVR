using OasisBlazor_SVR.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OasisBlazor_SVR.Services
{
    public interface IApiService
    {
        Task<IEnumerable<UserProfile>> GetAllUserProfilesAsync();
        Task<UserProfile> GetUserProfileAsync(int id);
        Task<UserProfile> CreateUserAsync(UserProfile userProfile);
        Task<UserProfile> UpdateUserProfileAsync(int id, UserProfile userProfile);
        Task DeleteUserProfileAsync(int id);
    }
}
