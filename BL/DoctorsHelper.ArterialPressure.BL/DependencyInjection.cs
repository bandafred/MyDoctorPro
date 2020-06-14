using AutoMapper;
using DoctorsHelper.ArterialPressure.BL.Email;
using DoctorsHelper.ArterialPressure.BL.Jwt;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelper.ArterialPressure.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddArterialPressureBusinessLogic(this IServiceCollection services,
            SimpleInjector.Container container, IConfiguration configuration)
        {
            var typesToRegister =
                container.GetTypesToRegister(typeof(IHandler<,>), typeof(DependencyInjection).Assembly);
            foreach (var type in typesToRegister)
            {
                container.Register(type);
            }

            services.Configure<JwtSecurityTokenConfiguration>(configuration.GetSection("JwtSecurityTokenSettings"));
            services.Configure<EmailSenderConfiguration>(configuration.GetSection("EmailSenderSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }

        public static IMapperConfigurationExpression AddArterialPressureAutoMapperConfiguration(
            this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile<MappingProfile>();

            return mapperConfigurationExpression;
        }
    }
}
