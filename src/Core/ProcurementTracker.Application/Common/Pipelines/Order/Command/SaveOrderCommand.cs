using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.OrderItemDTOs;

namespace ProcurementTracker.Application.Common.Pipelines.Order.Command
{
    public record SaveOrderCommand(): IRequest<ResultDTO>
    {
        public decimal TotalPrice { get; set; }
        public long SupplierId { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool IsProceesed { get; set; }
       
        public List<OrderItemDTO> OrderItems { get; set; }
    }

    public class SaveOrderCommandHandler : IRequestHandler<SaveOrderCommand, ResultDTO>
    {
        private readonly IOrderService _orderService;
        public SaveOrderCommandHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<ResultDTO> Handle(SaveOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDTO = new OrderDTO()
            {
                TotalPrice = request.TotalPrice,
                SupplierId = request.SupplierId,
                ShippingDate = request.ShippingDate,
                IsProceesed = false,
                OrderItems = request.OrderItems,
            };

            var response = await _orderService.SaveOrder(orderDTO, cancellationToken);

            return response;
        }
    }
}
