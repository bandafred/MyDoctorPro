using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelper.Calculators.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCalculatorsBusinessLogic(this IServiceCollection services,
            SimpleInjector.Container container)
        {
            var typesToRegister =
                container.GetTypesToRegister(typeof(IHandler<,>), typeof(DependencyInjection).Assembly);
            foreach (var type in typesToRegister)
            {
                container.Register(type);
            }

            return services;
        }
    }
}
