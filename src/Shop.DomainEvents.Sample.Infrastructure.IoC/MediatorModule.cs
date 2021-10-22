using System.Reflection;
using Autofac;
using MediatR;
using Shop.DomainEvents.Sample.ApplicationService;
using Shop.DomainEvents.Sample.ApplicationService.DomainEventsHandlers.OrderStarted;
using Shop.DomainEvents.Sample.ApplicationService.Interfaces;

namespace Shop.DomainEvents.Sample.Infrastructure.IoC
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
            
            builder.RegisterType<CreateOrderUseCase>().As<ICreateOrderUseCase>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(OrderStartedHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));
            
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}
