using KrzaqTools;
using System.Collections.Generic;
using System.Linq;

namespace Core.Database.Services
{
    public static class DbServiceHelper
    {
        public static IReadOnlyCollection<IServiceInfo> Services { get; } = GetAllServices();

        private static IReadOnlyCollection<IServiceInfo> GetAllServices()
        {
            var types = ReflectionToolbox.GetAllNonAbstractImplementingInterface(typeof(IDbService));
            var services = types.Select(type => new ServiceInfo(type)).ToList();
            return services;
        }
    }
}
