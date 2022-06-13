using Microsoft.Extensions.DependencyInjection;
using PttApp.Application.Abstractions;
using PttApp.Models;
using PttApp.Persistence.Managers;
using PttApp.Views.HomeTabbedPageViews;

namespace PttApp
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IHomeManager, HomeManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();

            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<Home>();
            services.AddTransient<Category>();
            services.AddTransient<Account>();
            services.AddTransient<Product>();
          

            return services;
        }
    }
}
