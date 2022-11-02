using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequests.Query
{
    public record GetPurchaseRequestByIdQuery(long id) : IRequest<PurchaseRequest>;


    public class GetPurchaseRequestByIdQueryHandler : IRequestHandler<GetPurchaseRequestByIdQuery, PurchaseRequest>
    {
        private readonly IPurchaseRequestQueryRepository _purchaseRequestQueryRepository;
        public GetPurchaseRequestByIdQueryHandler(IPurchaseRequestQueryRepository purchaseRequestQueryRepository)
        {
            this._purchaseRequestQueryRepository = purchaseRequestQueryRepository;
        }
        public async Task<PurchaseRequest> Handle(GetPurchaseRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var purchaseRequest = await _purchaseRequestQueryRepository.GetById(request.id, cancellationToken);

            return purchaseRequest;
        }
    }
}
