using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Orders.Command;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        public OrderService(IMediator mediator, ICurrentUserService currentUserService)
        {
            this._mediator = mediator;
            this._currentUserService = currentUserService;
        }

        public async Task<ResultDTO> SaveOrder(OrderDTO orderDTO, CancellationToken cancellationToken)
        {
            var response = new ResultDTO();

            try
            {

                var order = new Order()
                {
                    ReferenceId = string.Format("{0}_Order", Guid.NewGuid()),
                    IsActive = true,
                    IsProceesed = false,
                    TotalPrice = orderDTO.TotalPrice,
                    ShippingDate = orderDTO.ShippingDate,
                    ShippingAddress = "ABC",
                    OrderStatus = OrderStatus.Pending,
                    OrderByUserId = 1,

                };

                order.OrderItems = new HashSet<OrderItem>();

                foreach (var item in orderDTO.OrderItems)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderId = order.Id,
                        NumberOfItems = item.NumberOfItems,
                        ProductId = item.ProductId,

                    };

                    order.OrderItems.Add(orderItem);
                }

                await _mediator.Send(new CreateOrderCommand()
                {
                    Order = order
                });

                response.IsSuccess = true;
                response.Message = "Order save has been successfull";

            }catch (Exception ex)
            {
               response.IsSuccess = false;
               response.Message = "Error has been Occured Please Try again";
            }
           
            return response;
        }
    }
}
