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
    public record PurchaseRequestProductItemGetAllQuery() : IRequest<List<PurchaseRequestProductItem>>;

    public class PurchaseRequestProductItemGetAllQueryHandler : IRequestHandler<PurchaseRequestProductItemGetAllQuery, List<PurchaseRequestProductItem>>
    {
        private readonly IPurchaseRequestProductItemQueryRepository _purchaseRequestProductItemQueryRepository;
        public PurchaseRequestProductItemGetAllQueryHandler(IPurchaseRequestProductItemQueryRepository purchaseRequestProductItemQueryRepository)
        {
            this._purchaseRequestProductItemQueryRepository = purchaseRequestProductItemQueryRepository;
        }
        public async Task<List<PurchaseRequestProductItem>> Handle(PurchaseRequestProductItemGetAllQuery request, CancellationToken cancellationToken)
        {
            var purchaseRequestProductItems = await _purchaseRequestProductItemQueryRepository.GetAll(cancellationToken);

            return purchaseRequestProductItems;
        }
    }
}
