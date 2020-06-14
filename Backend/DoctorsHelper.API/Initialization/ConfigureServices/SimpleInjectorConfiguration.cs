using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace DoctorsHelper.API.Initialization.ConfigureServices
{
    public static class SimpleInjectorConfiguration
    {
        /// <summary>
        /// Добавление основной настройки SimpleInjector
        /// </summary>
        /// <param name="container">Контейнер SimpleInjector <see cref="Container"/></param>
        public static IServiceCollection AddSimpleInjectorCore(this IServiceCollection services, Container container)
        {
            // Sets up the basic configuration that for integrating Simple Injector with
            // ASP.NET Core by setting the DefaultScopedLifestyle, and setting up auto
            // cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // PageModels and TagHelpers are not needed when you build a Web API.
                    .AddControllerActivation()
                    .AddViewComponentActivation();

                // Optionally, allow application components to depend on the non-generic
                // ILogger (Microsoft.Extensions.Logging) or IStringLocalizer
                // (Microsoft.Extensions.Localization) abstractions.
                options.AddLogging();
                options.AddLocalization();
            });

            return services;
        }
    }
}