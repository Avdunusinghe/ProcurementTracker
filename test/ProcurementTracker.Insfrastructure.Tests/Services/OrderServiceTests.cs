using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using ProcurementTracker.Application.Orders.Command;
using ProcurementTracker.Application.Orders.Query;
using ProcurementTracker.Application.PurchaseRequests.Command;
using ProcurementTracker.Application.PurchaseRequests.Query;
using ProcurementTracker.Application.PurchaseRequestsItems.Command;
using ProcurementTracker.Application.PurchaseRequestsItems.Query;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Infrastructure.Services;
using ProcurementTracker.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Services.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public async Task SaveOrderTest_Success()
        {
            var cancellationToken = new CancellationToken();
            var orderDTO = new OrderDTO()
            {
                Id = 0,
                TotalPrice = 5000,
                SupplierId = 2,
                ShippingDate = DateTime.Now,
                IsProceesed = true,
                OrderStatus = (Domain.Enums.OrderStatus)1,



            };

            orderDTO.OrderItems.Add(new OrderItemDTO()
            {
                Id = 0,
                ProductId = 2,
                OrderId = 0,
                NumberOfItems = 0,
            });

            var mediator = new Mock<IMediator>();
            var currentUserService = new Mock<ICurrentUserService>();

            var order = new Order()
            {
                Id = 1,
                ReferenceId = "c519639a-6797-4572-ac79-c08bbb45b5b2_Order",
                TotalPrice = 3000,
                ShippingAddress = "ABC",
                ShippingDate = DateTime.Now,
                OrderStatus = (Domain.Enums.OrderStatus)1,
                IsActive = true,
                OrderByUserId = 1,


            };
            order.OrderItems = new HashSet<OrderItem>();

            order.OrderItems.Add(new OrderItem()
            {
                OrderId = order.Id,
                ProductId = 1,
                NumberOfItems = 45,
                Id = 1
            });



            mediator.Setup(x => x.Send(new GetOrderByIdQuery(orderDTO.Id), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult<Order>(null));

            var newOrder = new Order()
            {
                Id = 5,
                ReferenceId = string.Format("{0}_Order", Guid.NewGuid()),
                TotalPrice = orderDTO.TotalPrice,
                ShippingAddress = "ABC",
                ShippingDate = DateTime.Now,
                OrderStatus = (Domain.Enums.OrderStatus)1,
                IsActive = true,
                OrderByUserId = 0,
                SupplierId = orderDTO.SupplierId,
                IsProceesed = false,
            };

            newOrder.OrderItems = new HashSet<OrderItem>();

            foreach (var item in orderDTO.OrderItems)
            {
                newOrder.OrderItems.Add(new OrderItem()
                {
                    Id = newOrder.Id,
                    ProductId = item.ProductId,
                    NumberOfItems = item.NumberOfItems,

                });
            }

            mediator.Setup(x => x.Send(new CreateOrderCommand() { Order = newOrder }, It.IsAny<CancellationToken>()));


            var orderService = new OrderService(mediator.Object, currentUserService.Object);
            var response = await orderService.SaveOrder(orderDTO, cancellationToken);


            Assert.IsTrue(response.IsSuccess);

        }

        [TestMethod()]
        public async Task SaveOrderTest_update_Success()
        {
            var cancellationToken = new CancellationToken();
            var orderDTO = new OrderDTO()
            {
                Id = 0,
                TotalPrice = 5000,
                SupplierId = 2,
                ShippingDate = DateTime.Now,
                IsProceesed = true,
                OrderStatus = (Domain.Enums.OrderStatus)1,



            };

            orderDTO.OrderItems.Add(new OrderItemDTO()
            {
                Id = 0,
                ProductId = 2,
                OrderId = 0,
                NumberOfItems = 0,
            });

            var mediator = new Mock<IMediator>();
            var currentUserService = new Mock<ICurrentUserService>();

            var order = new Order()
            {
                Id = 1,
                ReferenceId = "c519639a-6797-4572-ac79-c08bbb45b5b2_Order",
                TotalPrice = 3000,
                ShippingAddress = "ABC",
                ShippingDate = DateTime.Now,
                OrderStatus = (Domain.Enums.OrderStatus)1,
                IsActive = true,
                OrderByUserId = 1,


            };
            order.OrderItems = new HashSet<OrderItem>();

            order.OrderItems.Add(new OrderItem()
            {
                OrderId = order.Id,
                ProductId = 1,
                NumberOfItems = 45,
                Id = 1
            });



            mediator.Setup(x => x.Send(new GetOrderByIdQuery(orderDTO.Id), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult<Order>(order));

            order.OrderStatus = orderDTO.OrderStatus;
            order.SupplierId = orderDTO.SupplierId;
            order.TotalPrice = orderDTO.TotalPrice;
            order.ShippingDate = orderDTO.ShippingDate;
            order.ShippingAddress = "ABC";
            order.OrderStatus = orderDTO.OrderStatus;



            mediator.Setup(x => x.Send(new EditOrderCommand() { Order = order }, It.IsAny<CancellationToken>()));


            var orderService = new OrderService(mediator.Object, currentUserService.Object);
            var response = await orderService.SaveOrder(orderDTO, cancellationToken);


            Assert.IsTrue(response.IsSuccess);


        }

        [TestMethod()]
        public async Task SavePurchaseRequestTest_Success()
        {
            var cancellationToken = new CancellationToken();

            var purchaseRequestDTO = new PurchaseRequestDTO()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "Test",
                SupplierId = 1,
                TotalPrice = 750,

            };

            purchaseRequestDTO.PurchaseRequestProductItems.Add(new PurchaseRequestProductItemDTO()
            {
                 Id = 0,
                 ProductId = 2,
                 NumberOfItem = 1,
                 
            });

            var purchaseRequest = new PurchaseRequest()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "test",
                SupplierId = 1,
                IsActive = true,
                TotalPrice = 5600,
                StatusChangedById = 1,

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

            var mediator = new Mock<IMediator>();
            var currentUserService = new Mock<ICurrentUserService>();

            mediator.Setup(x => x.Send(new GetPurchaseRequestByIdQuery(purchaseRequestDTO.Id), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult<PurchaseRequest>(null));

            var newPurchaseRequest = new PurchaseRequest()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "test",
                SupplierId = 1,
                IsActive = true,
                TotalPrice = 5600,
                StatusChangedById = 1,
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

            mediator.Setup(x => x.Send(new CreatePurchaseRequestCommand(), It.IsAny<CancellationToken>()))
             .Returns(Task.FromResult<PurchaseRequest>(null));

            var orderService = new OrderService(mediator.Object, currentUserService.Object);
            var response = await orderService.SavePurchaseRequest(purchaseRequestDTO, cancellationToken);

            Assert.IsTrue(response.IsSuccess);


        }

        [TestMethod()]
        public async Task SavePurchaseRequestTest_Update_Success()
        {
            var cancellationToken = new CancellationToken();

            var purchaseRequestDTO = new PurchaseRequestDTO()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "Test",
                SupplierId = 1,
                TotalPrice = 750,

            };

            purchaseRequestDTO.PurchaseRequestProductItems.Add(new PurchaseRequestProductItemDTO()
            {
                Id = 0,
                ProductId = 2,
                NumberOfItem = 1,

            });

            var purchaseRequest = new PurchaseRequest()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "test",
                SupplierId = 1,
                IsActive = true,
                TotalPrice = 5600,
                StatusChangedById = 1,

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

            var mediator = new Mock<IMediator>();
            var currentUserService = new Mock<ICurrentUserService>();

            mediator.Setup(x => x.Send(new GetPurchaseRequestByIdQuery(purchaseRequestDTO.Id), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult<PurchaseRequest>(purchaseRequest));

            var newPurchaseRequest = new PurchaseRequest()
            {
                PurchaseRequestStatus = (Domain.Enums.PurchaseRequestStatus)1,
                RequiredDeliveryDate = DateTime.Now,
                Description = "test",
                SupplierId = 1,
                IsActive = true,
                TotalPrice = 5600,
                StatusChangedById = 1,
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

            var purchaseRequestProductItemObj = new PurchaseRequestProductItem()
            {
                Id = 1,
                NumberOfItem = 600,
                PurchaseRequestId = 1
            };

            mediator.Setup(x => x.Send(new PurchaseRequestProductItemGetByRequestIdQuery(purchaseRequest.Id), It.IsAny<CancellationToken>()))
             .Returns(Task.FromResult<PurchaseRequestProductItem>(purchaseRequestProductItemObj));;


            mediator.Setup(x => x.Send(new CreatePurchaseRequestProductItemCommand() {PurchaseRequestProdcuctItem = purchaseRequest.PurchaseRequestProductItems.FirstOrDefault() }, It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<PurchaseRequestProductItem>(null)); ;

            var orderService = new OrderService(mediator.Object, currentUserService.Object);
            var response = await orderService.SavePurchaseRequest(purchaseRequestDTO, cancellationToken);

            Assert.IsTrue(response.IsSuccess);


        }
    }
}