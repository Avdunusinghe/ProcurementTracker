using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;

namespace ProcurementTracker.Application.Orders.Query
{
    public record GetAllOrderQuery() : IRequest<List<Order>>;


    public class GetOrderQueryCommand : IRequestHandler<GetAllOrderQuery, List<Order>>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetOrderQueryCommand(IOrderQueryRepository orderQueryRepository)
        {
            this._orderQueryRepository = orderQueryRepository;
        }
        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
           var orders = await _orderQueryRepository.GetAll(cancellationToken);

           return orders;

        }
    }
}
