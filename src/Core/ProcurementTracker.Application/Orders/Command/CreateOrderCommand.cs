using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;

namespace ProcurementTracker.Application.Orders.Command
{
    public record CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderCommandRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderCommandRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.AddAsync(request.Order, cancellationToken);
           
            return order;
        }
    }
}
