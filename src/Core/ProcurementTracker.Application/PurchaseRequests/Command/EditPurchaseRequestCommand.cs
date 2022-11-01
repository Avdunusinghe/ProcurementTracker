using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Domain.Repositories.Query;

namespace ProcurementTracker.Application.PurchaseRequests.Command
{
    public record EditPurchaseRequestCommand : IRequest<PurchaseRequest>
    {
        public PurchaseRequest PurchaseRequest { get; set; }
    }

    public class EditPurchaseRequestCommandHandler : IRequestHandler<EditPurchaseRequestCommand, PurchaseRequest>
    {
        private readonly IPurchaseRequestQueryRepository _purchaseRequestQueryRepository;
        private readonly IPurchaseRequestCommandRepository _purchaseRequestCommandRepository;

        public EditPurchaseRequestCommandHandler
        (
            IPurchaseRequestQueryRepository purchaseRequestQueryRepository, 
            IPurchaseRequestCommandRepository purchaseRequestCommandRepository
        )
        {
            this._purchaseRequestQueryRepository = purchaseRequestQueryRepository;
            this._purchaseRequestCommandRepository = purchaseRequestCommandRepository;
        }
        public async Task<PurchaseRequest> Handle(EditPurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _purchaseRequestCommandRepository
                      .UpdateAsync(request.PurchaseRequest, cancellationToken);

            }catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            var modifiedPurchaseRequest = await _purchaseRequestQueryRepository
                                                .GetById(request.PurchaseRequest.Id, cancellationToken);

            return modifiedPurchaseRequest;
        }
    }
}
