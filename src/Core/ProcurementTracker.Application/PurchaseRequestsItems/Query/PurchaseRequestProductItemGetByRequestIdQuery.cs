using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequestsItems.Query
{
   
    
    public record PurchaseRequestProductItemGetByRequestIdQuery(long id) : IRequest<PurchaseRequestProductItem>;

    public class PurchaseRequestProductItemGetByRequestIdQueryHandler : IRequestHandler<PurchaseRequestProductItemGetByRequestIdQuery, PurchaseRequestProductItem>
    {
        private readonly IPurchaseRequestProductItemQueryRepository _purchaseRequestProductItemQueryRepository;
        public PurchaseRequestProductItemGetByRequestIdQueryHandler(IPurchaseRequestProductItemQueryRepository purchaseRequestProductItemQueryRepository)
        {
            this._purchaseRequestProductItemQueryRepository = purchaseRequestProductItemQueryRepository;
        }
        public async Task<PurchaseRequestProductItem> Handle(PurchaseRequestProductItemGetByRequestIdQuery request, CancellationToken cancellationToken)
        {
            var purchaseRequestProductItems =  _purchaseRequestProductItemQueryRepository.GetUserByPurchaseRequestId(request.id);

            return purchaseRequestProductItems;
        }
    }
}
