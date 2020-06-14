using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using DoctorsHelper.BL.Core.Interfaces;

namespace DoctorsHelper.ArterialPressure.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(typeof(MappingProfile).Assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var typesIMapFrom = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();
            foreach (var type in typesIMapFrom)
            {
                var instance = Activator.CreateInstance(type);
                    var methodInfo = type.GetMethod(nameof(IMapFrom<string>.Mapping)) ??
                                     type.GetInterface(typeof(IMapFrom<>).Name).GetMethod(nameof(IMapFrom<object>.Mapping));
                    methodInfo?.Invoke(instance, new object[] { this });
            }

            var typesIMapTo = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .ToList();
            foreach (var type in typesIMapTo)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(nameof(IMapTo<string>.Mapping)) ??
                                 type.GetInterface(typeof(IMapTo<>).Name).GetMethod(nameof(IMapTo<object>.Mapping));
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
