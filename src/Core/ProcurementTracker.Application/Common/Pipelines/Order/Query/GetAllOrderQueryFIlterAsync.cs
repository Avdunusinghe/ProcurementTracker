using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.Order.Query
{
    public record GetAllOrderQueryFilterAsync() : IRequest<List<OrderContainerDTO>>
    {
        public int OrderStatus { get; set; }
        public long Supplier { get; set; }
    }

    public class GetAllOrderQueryFilterAsyncHandler : IRequestHandler<GetAllOrderQueryFilterAsync, List<OrderContainerDTO>>
    {
        private readonly IOrderService _orderService;
        public GetAllOrderQueryFilterAsyncHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<List<OrderContainerDTO>> Handle(GetAllOrderQueryFilterAsync request, CancellationToken cancellationToken)
        {
            var filter = new OrderFilterDTO()
            {
                Supplier = request.Supplier,
                OrderStatus = request.OrderStatus,
            };

            var orderDataSet = await _orderService.GetAllOrders(filter, cancellationToken);

            return orderDataSet;
        }
    }
}
