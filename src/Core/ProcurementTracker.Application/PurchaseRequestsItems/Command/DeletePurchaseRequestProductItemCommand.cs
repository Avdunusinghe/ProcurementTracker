using MediatR;
using ProcurementTracker.Application.Response.Common;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Domain.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.PurchaseRequestsItems.Command
{
    public record DeletePurchaseRequestProductItemCommand(long id) : IRequest<DeleteResponseDTO>;


    public class DeletePurchaseRequestProductItemCommandHandler : IRequestHandler<DeletePurchaseRequestProductItemCommand, DeleteResponseDTO>
    {
        private readonly IPurchaseRequestProductItemQueryRepository _purchaseRequestProductItemQueryRepository;
        private readonly IPurchaseRequestProductItemCommandRepository _purchaseRequestProductItemCommandRepository;

        public DeletePurchaseRequestProductItemCommandHandler
            (
            IPurchaseRequestProductItemQueryRepository purchaseRequestProductItemQueryRepository,
            IPurchaseRequestProductItemCommandRepository purchaseRequestProductItemCommandRepository
            )
        {
            this._purchaseRequestProductItemQueryRepository = purchaseRequestProductItemQueryRepository;
            this._purchaseRequestProductItemCommandRepository = purchaseRequestProductItemCommandRepository;
        }
        public async Task<DeleteResponseDTO> Handle(DeletePurchaseRequestProductItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchaseRequestProductItem = await _purchaseRequestProductItemQueryRepository.GetById(request.id, cancellationToken);

                await _purchaseRequestProductItemCommandRepository.DeleteAsync(purchaseRequestProductItem, cancellationToken);


            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
            return new DeleteResponseDTO() { IsSuccess = true, Message = "purchaseRequestProductItem has been deleted!." };
        }
    }
}
