﻿using AutoMapper;
using DoctorsHelper.BL.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorsHelper.Dictionaries.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDictionariesBusinessLogic(this IServiceCollection services,
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

        public static IMapperConfigurationExpression AddDictionariesAutoMapperConfiguration(
            this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile<MappingProfile>();

            return mapperConfigurationExpression;
        }
    }
}
