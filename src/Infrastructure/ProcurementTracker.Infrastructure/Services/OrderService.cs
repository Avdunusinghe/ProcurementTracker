using MediatR;
using ProcurementTracker.Application.Common.Helper;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using ProcurementTracker.Application.Orders.Command;
using ProcurementTracker.Application.Orders.Query;
using ProcurementTracker.Application.PurchaseRequests.Command;
using ProcurementTracker.Application.PurchaseRequests.Query;
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

        public async Task<ResultDTO> AcceptPurchaseRequest(PurchaseRequestDTO purchaseRequestDTO, CancellationToken cancellationToken)
        {
            var response = new ResultDTO();
            try
            {
                var order = new Order()
                {
                    ReferenceId = string.Format("_Order{0}", Guid.NewGuid()),
                    IsActive = true,
                    IsProceesed = true,
                    SupplierId = purchaseRequestDTO.SupplierId,
                    TotalPrice = purchaseRequestDTO.TotalPrice,
                    ShippingDate = purchaseRequestDTO.RequiredDeliveryDate,
                    ShippingAddress = "ABC",
                    OrderStatus = OrderStatus.Approved,
                    OrderByUserId = _currentUserService.UserId!.Value,

                };

                order.OrderItems = new HashSet<OrderItem>();

                foreach (var item in purchaseRequestDTO.PurchaseRequestProductItems)
                {
                    var orderItem = new OrderItem()
                    {
                        OrderId = order.Id,
                        NumberOfItems = item.NumberOfItem,
                        ProductId = item.ProductId,

                    };

                    order.OrderItems.Add(orderItem);
                }


                await _mediator.Send(new CreateOrderCommand()
                {
                    Order = order
                });

                response.IsSuccess = true;
                response.Message = "PurchaseRequest has been aceepted successfull";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been Occured Please Try again";
            }

            return response;
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
                order.OrderStatusResult = EnumHelper.GetEnumDescription((OrderStatus)item.OrderStatus);  
                order.SupplierName = item.Supplier.SupplierName;
                order.SupplierId = item.SupplierId;
                order.TotalPrice = item.TotalPrice;
                order.ShippingAddress = item.ShippingAddress;
                order.LastModifiedByName = item.LastUpdatedById.HasValue ? item.LastUpdatedBy.FirstName : string.Empty;

                foreach (var orderItem in item.OrderItems)
                {
                    order.OrderItems.Add(new OrderItemDTO()
                    {
                        Id = orderItem.Id,
                        NumberOfItems = orderItem.NumberOfItems,
                        ProductId = orderItem.ProductId,
                        ProductName = orderItem.Product.Name,
                        ItemPrice = orderItem.Product.Price,
                        OrderId = orderItem.OrderId,
                        TotalPriceProduct = orderItem.NumberOfItems * orderItem.Product.Price
                    });
                }

                orderDataSet.Add(order);
                
            }

            return orderDataSet;


        }

        public async Task<List<PurchaseRequestContainerDTO>> GetAllPurchaseRequest(PurchaseRequestFilterDTO filter, CancellationToken cancellationToken)
        {
            var response = new List<PurchaseRequestContainerDTO>();

            var purchaseRequests = await _mediator.Send(new GetAllPurchaseRequestQuery());

            if(filter.PurchaseRequestStatus != 0)
            {
                purchaseRequests = purchaseRequests
                                  .Where(x=>x.PurchaseRequestStatus == filter.PurchaseRequestStatus)
                                  .OrderByDescending(x=>x.Created)
                                  .ToList();

            }

            foreach (var item in purchaseRequests)
            {
                var purchaseRequest = new PurchaseRequestContainerDTO();

                purchaseRequest.Id = item.Id;
                purchaseRequest.SupplierId = item.SupplierId;
                purchaseRequest.SupplierName = item.Supplier.SupplierName;
                purchaseRequest.StatusChangedByName = item.StatusChangedBy.FirstName;
                purchaseRequest.TotalPrice = item.TotalPrice;

                foreach(var product in item.PurchaseRequestProductItems)
                {
                    purchaseRequest.PurchaseRequestProductItems.Add(new PurchaseRequestProductItemDTO()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.Product.Name,
                        NumberOfItem = product.NumberOfItem,
                    });
                }

                response.Add(purchaseRequest);

            }

            return response;

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
                    OrderStatus = orderDTO.OrderStatus,
                    OrderByUserId = _currentUserService.UserId!.Value,

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

                if(orderDTO.Id == 0)
                {
                    await _mediator.Send(new CreateOrderCommand()
                    {
                        Order = order
                    });

                    response.IsSuccess = true;
                    response.Message = "Order save has been successfull";
                }
                else
                {
                    await _mediator.Send(new EditOrderCommand()
                    {
                        Order = order
                    });

                    response.IsSuccess = true;
                    response.Message = "Order update has been successfull";
                }

               

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
                    PurchaseRequestStatus = purchaseRequestDTO.PurchaseRequestStatus,
                    RequiredDeliveryDate = purchaseRequestDTO.RequiredDeliveryDate,
                    Description = purchaseRequestDTO.Description,
                    SupplierId = purchaseRequestDTO.SupplierId,
                    IsActive = true,
                    TotalPrice = purchaseRequestDTO.TotalPrice,
                    StatusChangedById = _currentUserService.UserId!.Value

                };

                purchaseRequest.PurchaseRequestProductItems = new HashSet<PurchaseRequestProductItem>();

                foreach (var item in purchaseRequestDTO.PurchaseRequestProductItems)
                {
                    var purchaseRequestProductItem = new PurchaseRequestProductItem()
                    {
                        ProductId = item.ProductId,
                        NumberOfItem = item.NumberOfItem,
                        PurchaseRequestId = purchaseRequest.Id
                    };

                    purchaseRequest.PurchaseRequestProductItems.Add(purchaseRequestProductItem);
                }
                if(purchaseRequestDTO.Id == 0)
                {
                    await _mediator.Send(new CreatePurchaseRequestCommand()
                    {
                        PurchaseRequest = purchaseRequest
                    });

                    response.IsSuccess = true;
                    response.Message = "PurchaseRequest save has been successfull";
                }
                else
                {
                    await _mediator.Send(new EditPurchaseRequestCommand()
                    {
                        PurchaseRequest = purchaseRequest
                    });

                    response.IsSuccess = true;
                    response.Message = "PurchaseRequest update has been successfull";
                }

               

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
