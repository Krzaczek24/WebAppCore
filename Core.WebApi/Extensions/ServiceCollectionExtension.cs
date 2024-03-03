using Core.Shared.Interfaces;
using Core.WebApi.Models;
using KrzaqTools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Core.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreSingletonServices(this IServiceCollection services, params Assembly[] assemblies) => AddCoreServices(services, services.AddSingleton, assemblies);

        public static IServiceCollection AddCoreScopedServices(this IServiceCollection services, params Assembly[] assemblies) => AddCoreServices(services, services.AddScoped, assemblies);

        private static IServiceCollection AddCoreServices(this IServiceCollection services, Func<Type, Type, IServiceCollection> addServiceAction, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = ReflectionToolbox.GetAllNonAbstractImplementingInterface<ICoreService>(assembly);
                var coreServices = types.Select(ServiceInfo.FromImplementation).ToList();

                foreach (IServiceInfo service in coreServices)
                {
                    addServiceAction(service.InterfaceType, service.ServiceType);
                }
            }

            return services;
        }
    }
}
