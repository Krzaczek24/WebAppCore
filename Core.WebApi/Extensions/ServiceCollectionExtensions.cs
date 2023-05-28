using Core.Shared.Interfaces;
using Core.WebApi.Models;
using KrzaqTools;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Core.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreScopedServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = ReflectionToolbox.GetAllNonAbstractImplementingInterface<ICoreService>(assembly);
                var coreServices = types.Select(type => new ServiceInfo(type)).ToList();

                foreach (IServiceInfo service in coreServices)
                {
                    services.AddScoped(service.InterfaceType, service.ServiceType);
                }
            }

            return services;
        }
    }
}
