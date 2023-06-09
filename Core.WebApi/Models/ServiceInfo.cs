﻿using System;
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
        public ServiceInfo(Type serviceType)
        {
            InterfaceType = serviceType.Assembly.GetTypes().Single(t => t.IsInterface && t.Name == "I" + serviceType.Name);
            ServiceType = serviceType;
        }

        public Type InterfaceType { get; }
        public Type ServiceType { get; }
    }
}
