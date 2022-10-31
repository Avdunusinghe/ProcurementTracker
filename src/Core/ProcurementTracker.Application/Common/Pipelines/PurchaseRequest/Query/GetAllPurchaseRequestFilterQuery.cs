using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using ProcurementTracker.Domain.Enums;

namespace ProcurementTracker.Application.Common.Pipelines.PurchaseRequest.Query
{


    public record GetAllPurchaseRequestFilterQuery() : IRequest<List<PurchaseRequestContainerDTO>>
    {
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
    }

    public class GetAllPurchaseRequestFilterQueryHandler : IRequestHandler<GetAllPurchaseRequestFilterQuery, List<PurchaseRequestContainerDTO>>
    {
        private readonly IOrderService _orderService;
        public GetAllPurchaseRequestFilterQueryHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public async Task<List<PurchaseRequestContainerDTO>> Handle(GetAllPurchaseRequestFilterQuery request, CancellationToken cancellationToken)
        {
            var filter = new PurchaseRequestFilterDTO()
            {
                PurchaseRequestStatus = request.PurchaseRequestStatus,
            };

            var response = await _orderService.GetAllPurchaseRequest(filter, cancellationToken);

            return response;    
        }
    }
}
