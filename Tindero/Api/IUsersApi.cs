using System.Threading.Tasks;
using Tindero.Api.Responses;

namespace Tindero.Api
{
    public interface IUsersApi
    {
        Task<GetUsersResponse> GetUsersAsync(int page, bool forceRefresh = false);
        Task<GetUserResponse> GetUserAsync(int id, bool forceRefresh = false);
    }
}
