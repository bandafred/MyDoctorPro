using DoctorsHelper.ArterialPressure.Data.EFCore;
using DoctorsHelper.Dictionaries.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelper.API.Initialization.ConfigureServices
{
    /// <summary>
    /// Добавление настройки на контекст данных
    /// </summary>
    public static class PersistenceConfiguration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArterialPressureContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Main"),
                builder => builder.MigrationsAssembly(typeof(ArterialPressureContext).Assembly.FullName)));

            services.AddDbContext<DictionariesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Main"),
                    builder => builder.MigrationsAssembly(typeof(DictionariesContext).Assembly.FullName)));

            return services;
        }
    }
}
