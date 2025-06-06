using DevApi.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using MyApp.BAL;

namespace DevApi
{
    public static class Register
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<JWTFunction>();
            services.AddTransient<LoginService>();
            services.AddTransient<ItemGroupService>();
            services.AddTransient<TaxService>(); // Register TaxService for Tax API
            services.AddTransient<MenuService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<ItemService>(); // <-- Add this line
        }
    }
}
