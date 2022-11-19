using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequestsItems.Command
{
    public record CreatePurchaseRequestProductItemCommand : IRequest<PurchaseRequestProductItem>
    {
        public PurchaseRequestProductItem PurchaseRequestProdcuctItem { get; set; }
    }

    public class CreatePurchaseRequestProductItemCommandHandler : IRequestHandler<CreatePurchaseRequestProductItemCommand, PurchaseRequestProductItem>
    {
        private readonly IPurchaseRequestProductItemCommandRepository _purchaseRequestProductItemCommandRepository;

        public CreatePurchaseRequestProductItemCommandHandler(IPurchaseRequestProductItemCommandRepository purchaseRequestProductItemCommandRepository)
        {
            this._purchaseRequestProductItemCommandRepository = purchaseRequestProductItemCommandRepository;
        }
        public async Task<PurchaseRequestProductItem> Handle(CreatePurchaseRequestProductItemCommand request, CancellationToken cancellationToken)
        {
            var purchaseRequestProductItem = await _purchaseRequestProductItemCommandRepository
                                            .AddAsync(request.PurchaseRequestProdcuctItem, cancellationToken);

            return purchaseRequestProductItem;
        }
    }
}
