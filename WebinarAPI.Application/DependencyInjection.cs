using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebinarAPI.Application.Interfaces;
using WebinarAPI.Application.Services;

namespace WebinarAPI.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IPresentService, PresentService>();
            services.AddTransient<IWishlistService, WishlistService>();
            return services;
        }
    }
}
