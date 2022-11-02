using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.PurchaseRequest.Query
{
    public record GetPurchaseRequestByIdFilterQuery(long Id) : IRequest<PurchaseRequestContainerDTO>;


    public class GetPurchaseRequestByIdFilterQueryHandler : IRequestHandler<GetPurchaseRequestByIdFilterQuery, PurchaseRequestContainerDTO>
    {
        private readonly IOrderService _orderService;

        public GetPurchaseRequestByIdFilterQueryHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task<PurchaseRequestContainerDTO> Handle(GetPurchaseRequestByIdFilterQuery request, CancellationToken cancellationToken)
        {
            var response = await  _orderService.GetPurchaseRequestById(request.Id, cancellationToken);

            return response;
        }
    }
}
