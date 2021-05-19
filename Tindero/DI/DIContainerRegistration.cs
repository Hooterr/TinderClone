using Microsoft.Extensions.DependencyInjection;
using Tindero.Api;

namespace Tindero.DI
{
    public static class DIContainerRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection collection)
        {
            return collection
                .AddScoped<IUsersApi, UsersApi>();
        }
    }
}
