using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.OrderDTOs;
using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Application.Orders.Command;
using ProcurementTracker.Application.Orders.Query;
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
        public async Task SavePurchaseRequestTest()
        {
            var cancellationToken = new CancellationToken();

        }
    }
}