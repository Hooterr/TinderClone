using System.Threading.Tasks;
using Tindero.Api.Responses;

namespace Tindero.Api
{
    public class UsersApi : BaseCachedApiService, IUsersApi
    {

        public Task<GetUsersResponse> GetUsersAsync(int page, bool forceRefresh = false)
        {
            return GetAsync<GetUsersResponse>($"users?page={page}", forceRefresh: forceRefresh);
        }

        public Task<GetUserResponse> GetUserAsync(int id, bool forceRefresh = false)
        {
            return GetAsync<GetUserResponse>($"users/{id}", forceRefresh: forceRefresh);
        }
    }
}
