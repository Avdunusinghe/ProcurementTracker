﻿using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Orders.Query
{
    public record GetAllOrdersFormAsyncQueryCommand() : IRequest<IQueryable<Order>>;


    public class GetAllOrdersFormAsyncQueryCommandHandler : IRequestHandler<GetAllOrdersFormAsyncQueryCommand, IQueryable<Order>>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetAllOrdersFormAsyncQueryCommandHandler(IOrderQueryRepository orderQueryRepository)
        {
            this._orderQueryRepository = orderQueryRepository;
        }

        public async Task<IQueryable<Order>> Handle(GetAllOrdersFormAsyncQueryCommand request, CancellationToken cancellationToken)
        {
            var orders =  _orderQueryRepository.GetAllOrdersFormAsync();

            return orders;
        }
    }
}
