using System;
using System.Linq;

namespace Core.WebApi.Models
{
    internal interface IServiceInfo
    {
        public Type InterfaceType { get; }
        public Type ServiceType { get; }
    }

    internal class ServiceInfo : IServiceInfo
    {
        private ServiceInfo(Type serviceType)
        {
            ServiceType = serviceType;
            InterfaceType = serviceType.Assembly.GetTypes().SingleOrDefault(t => t.IsInterface && t.Name == "I" + serviceType.Name)
                ?? throw new InvalidOperationException($"No matching interface has been found for service [(I){serviceType.Name}]");
        }

        public Type InterfaceType { get; }
        public Type ServiceType { get; }

        public static ServiceInfo FromImplementation(Type serviceType) => new(serviceType);
    }
}
