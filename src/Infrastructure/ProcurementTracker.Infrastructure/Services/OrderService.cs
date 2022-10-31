using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using ProcurementTracker.Application.Orders.Command;
using ProcurementTracker.Application.Orders.Query;
using ProcurementTracker.Application.PurchaseRequests.Command;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Enums;

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

        public async Task<List<OrderContainerDTO>> GetAllOrders(OrderFilterDTO filter, CancellationToken cancellationToken)
        {
            var orderDataSet = new List<OrderContainerDTO>();

            var orders = await _mediator.Send(new GetAllOrdersFormAsyncQuery());


            if (filter.OrderStatus != 0)
            {
                orders = orders.Where(x => x.OrderStatus == (OrderStatus)filter.OrderStatus);
            }

            if(filter.Supplier != 0)
            {
                orders = orders.Where(x => x.SupplierId == filter.Supplier);
            }
           
            var availableDataSet = orders.OrderByDescending(x => x.Created).ToList();

            foreach(var item in availableDataSet)
            {
                var order = new OrderContainerDTO();

                order.Id = item.Id;
                order.ReferenceId = item.ReferenceId;
                order.IsProceesed = item.IsProceesed;
                order.ShippingDate = item.ShippingDate;
                order.OrderByName = item.OrderBy.FirstName;
                order.OrderStatus = item.OrderStatus;
                order.SupplierName = item.Supplier.SupplierName;
                order.LastModifiedByName = item.LastUpdatedById.HasValue ? item.LastUpdatedBy.FirstName : string.Empty;

                foreach (var orderItem in item.OrderItems)
                {
                    order.OrderItems.Add(new OrderItemDTO()
                    {
                        Id = orderItem.Id,
                        NumberOfItems = orderItem.NumberOfItems,
                        ProductId = orderItem.ProductId,
                        OrderId = orderItem.OrderId,
                    });
                }

                orderDataSet.Add(order);
                
            }

            return orderDataSet;


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
                    SupplierId = orderDTO.SupplierId,
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

        public async Task<ResultDTO> SavePurchaseRequest(PurchaseRequestDTO purchaseRequestDTO, CancellationToken cancellationToken)
        {
            var response = new ResultDTO();

            try
            {

                var purchaseRequest = new PurchaseRequest()
                {
                    PurchaseRequestStatus = PurchaseRequestStatus.WaitingForApproval,
                    RequiredDeliveryDate = purchaseRequestDTO.RequiredDeliveryDate,
                    Description = purchaseRequestDTO.Description,
                    SupplierId = purchaseRequestDTO.SupplierId,
                    IsActive = true,
                    TotalPrice = purchaseRequestDTO.TotalPrice,
                    StatusChangedById = 1

                };

                purchaseRequest.PurchaseRequestProductItems = new HashSet<PurchaseRequestProductItem>();

                foreach (var item in purchaseRequestDTO.PurchaseRequestProductItems)
                {
                    var purchaseRequestProductItem = new PurchaseRequestProductItem()
                    {
                        ProductId = purchaseRequestDTO.ProductId,
                        PurchaseRequestId = purchaseRequest.Id
                    };

                    purchaseRequest.PurchaseRequestProductItems.Add(purchaseRequestProductItem);
                }

                await _mediator.Send(new CreatePurchaseRequestCommand()
                {
                    PurchaseRequest = purchaseRequest
                });

                response.IsSuccess = true;
                response.Message = "PurchaseRequest save has been successfull";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been Occured Please Try again";
            }


            return response;
        }
    }
}
