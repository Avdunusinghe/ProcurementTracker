using MediatR;
using ProcurementTracker.Application.Common.Interfaces;
using ProcurementTracker.Application.Common.Response;
using ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs;
using ProcurementTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Pipelines.PurchaseRequest.Command
{
    public class AcceptPurchaseRequestCommand : IRequest<ResultDTO>
    {

        public long Id { get; set; }
        public long ProductId { get; set; }
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
        public DateTime RequiredDeliveryDate { get; set; }
        public string Description { get; set; }
        public long SupplierId { get; set; }
        public Decimal TotalPrice { get; set; }
        public string StatusChangedBy { get; set; }


        public List<PurchaseRequestProductItemDTO> PurchaseRequestProductItems { get; set; }
    }
    public class AcceptPurchaseRequestCommandHandler : IRequestHandler<AcceptPurchaseRequestCommand, ResultDTO>
    {
        private readonly IOrderService _orderService;
        public AcceptPurchaseRequestCommandHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public async Task<ResultDTO> Handle(AcceptPurchaseRequestCommand request, CancellationToken cancellationToken)
        {
            var purchaseRequestDTO = new PurchaseRequestDTO()
            {
                ProductId = request.ProductId,
                PurchaseRequestStatus = request.PurchaseRequestStatus,
                RequiredDeliveryDate = request.RequiredDeliveryDate,
                Description = request.Description,
                SupplierId = request.SupplierId,
                TotalPrice = request.TotalPrice,
                PurchaseRequestProductItems = request.PurchaseRequestProductItems,

            };
            var response = await _orderService.AcceptPurchaseRequest(purchaseRequestDTO, cancellationToken);

            return response;
        }
    }
}
