using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shop.DomainEvents.Sample.ApplicationService.Interfaces;
using Shop.DomainEvents.Sample.Infrastructure.IoC;

namespace Shop.DomainEvents.Sample.Presentation
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceProvider = ContainerConfiguration.Configure();

            var userId = Guid.NewGuid().ToString();

            var createOrderUseCase = serviceProvider.GetService<ICreateOrderUseCase>();
            await createOrderUseCase.Create(userId);
        }
    }
}
