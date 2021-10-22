using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.DomainEvents.Sample.ApplicationService.Interfaces;
using Shop.DomainEvents.Sample.Core.Orders;
using Shop.DomainEvents.Sample.Infrastructure;

namespace Shop.DomainEvents.Sample.ApplicationService
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly ILogger<CreateOrderUseCase> _logger;
        private readonly IMediator _mediator;

        public CreateOrderUseCase(ILogger<CreateOrderUseCase> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Create(string userId)
        {
            var order = new Order(userId);
            order.AddItem("A8909", "IPhone 13", 1, 10799);

            _logger.LogInformation("Created a new order");

            await  _mediator.DispatchEvents(order);
        }
    }
}