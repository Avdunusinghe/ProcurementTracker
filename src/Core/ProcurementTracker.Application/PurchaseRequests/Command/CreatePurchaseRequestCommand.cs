using MediatR;
using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequests.Command
{
    public record CreatePurchaseRequestCommand : IRequest<PurchaseRequest>
    {
        public PurchaseRequest PurchaseRequest { get; set; }
    }

    public class CreatePurchaseRequestCommandHandler : IRequestHandler<CreatePurchaseRequestCommand, PurchaseRequest>
    {
        private readonly IPurchaseRequestCommandRepository _purchaseRequestCommandRepository;
        public CreatePurchaseRequestCommandHandler(IPurchaseRequestCommandRepository purchaseRequestCommandRepository)
        {
            this._purchaseRequestCommandRepository = purchaseRequestCommandRepository;
        }
        public Task<PurchaseRequest> Handle(CreatePurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            var PurchaseRequest = _purchaseRequestCommandRepository.AddAsync(request.PurchaseRequest, cancellationToken);

            return PurchaseRequest;
        }
    }
}
