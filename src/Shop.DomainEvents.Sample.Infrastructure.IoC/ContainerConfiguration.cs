using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Shop.DomainEvents.Sample.Infrastructure.IoC
{
    public static class ContainerConfiguration
    {
        public static IServiceProvider Configure()
        {
            var serviceColection = new ServiceCollection();
            serviceColection.AddLogging(l => l.AddConsole());
            
            var container = new ContainerBuilder();
            container.Populate(serviceColection);

            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }
    }
}