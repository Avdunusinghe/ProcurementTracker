using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequestsItems.Command
{
    public record EditPurchaseRequestProductItemCommand : IRequest<PurchaseRequestProductItem>
    {
        public PurchaseRequestProductItem PurchaseRequestProductItem { get; set; }
    }

    public class EditPurchaseRequestProductItemCommandHandler : IRequestHandler<EditPurchaseRequestProductItemCommand, PurchaseRequestProductItem>
    {
        private readonly IPurchaseRequestProductItemQueryRepository _purchaseRequestProductItemQueryRepository;
        private readonly IPurchaseRequestProductItemCommandRepository _purchaseRequestProductItemCommandRepository;

        public EditPurchaseRequestProductItemCommandHandler
            (
            IPurchaseRequestProductItemQueryRepository purchaseRequestProductItemQueryRepository, 
            IPurchaseRequestProductItemCommandRepository purchaseRequestProductItemCommandRepository
            )
        {
            this._purchaseRequestProductItemQueryRepository = purchaseRequestProductItemQueryRepository;
            this._purchaseRequestProductItemCommandRepository= purchaseRequestProductItemCommandRepository;
        }
        public async Task<PurchaseRequestProductItem> Handle(EditPurchaseRequestProductItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _purchaseRequestProductItemCommandRepository.AddAsync(request.PurchaseRequestProductItem, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            var modifiedOrder = await _purchaseRequestProductItemQueryRepository.GetById(request.PurchaseRequestProductItem.Id, cancellationToken);

            return modifiedOrder;
        }
    }
}
