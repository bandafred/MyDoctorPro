using DoctorsHelper.ArterialPressure.Data;
using DoctorsHelper.ArterialPressure.Data.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelper.API.Initialization.ConfigureServices
{
    public static class IdentityConfiguration
    {
        /// <summary>
        /// Добавление настройки на Identity
        /// </summary>
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddIdentityCore<User>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ArterialPressureContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}