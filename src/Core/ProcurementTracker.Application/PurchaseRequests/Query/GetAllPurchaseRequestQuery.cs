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
    public record GetAllPurchaseRequestQuery() : IRequest<List<PurchaseRequest>>;


    public class GetAllPurchaseRequestHandler : IRequestHandler<GetAllPurchaseRequestQuery, List<PurchaseRequest>>
    {
        private readonly IPurchaseRequestQueryRepository _purchaseRequestQueryRepository;
        public GetAllPurchaseRequestHandler(IPurchaseRequestQueryRepository purchaseRequestQueryRepository)
        {
            this._purchaseRequestQueryRepository = purchaseRequestQueryRepository;
        }
        public async Task<List<PurchaseRequest>> Handle(GetAllPurchaseRequestQuery request, CancellationToken cancellationToken)
        {
            var PurchaseRequests = await _purchaseRequestQueryRepository.GetAll(cancellationToken);
            return PurchaseRequests;
        }
    }
}
