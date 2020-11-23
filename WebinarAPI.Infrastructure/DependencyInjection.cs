using Microsoft.Extensions.DependencyInjection;
using WebinarAPI.Domain.Interfaces;

namespace WebinarAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDbContext, Context>();
            return services;
        }
    }
}
