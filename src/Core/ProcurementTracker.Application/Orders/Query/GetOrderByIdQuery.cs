using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Orders.Query
{
    public record GetOrderByIdQuery(long id) : IRequest<Order>;
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;
        public GetOrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            this._orderQueryRepository = orderQueryRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueryRepository.GetById(request.id, cancellationToken);
            return order;
        }
    }
}
