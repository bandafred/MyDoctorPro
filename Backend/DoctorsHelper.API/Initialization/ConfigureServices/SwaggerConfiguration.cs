using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace DoctorsHelper.API.Initialization.ConfigureServices
{
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Добавление настройки на Swagger
        /// </summary>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //TODO: Add information for swagger
            //https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio#customize-api-documentation
            // Register the Swagger services
            services.AddSwaggerDocument(config => {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"));
                config.AddSecurity("JWT token", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Description = "Скопируйте 'Bearer ' + валидный JWT токен в поле",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
                //Так настраиваются названия и версии
                //config.PostProcess = (document) =>
                //{
                //    document.Info.Version = "v1";
                //    document.Info.Title = "MyRest-API";
                //    document.Info.Description = "ASP.NET Core 3.1 MyRest-API";
                //};
            });

            return services;
        }
    }
}