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
    public record SavePurchaseRequestCommand : IRequest<ResultDTO>
    {
        public long ProductId { get; set; }
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
        public DateTime RequiredDeliveryDate { get; set; }
        public string Description { get; set; }
        public long SupplierId { get; set; }
        public Decimal TotalPrice { get; set; }
        public string StatusChangedBy { get; set; }


        public List<PurchaseRequestProductItemDTO> PurchaseRequestProductItems { get; set; }
    }

    public class SavePurchaseRequestCommandHandler : IRequestHandler<SavePurchaseRequestCommand, ResultDTO>
    {
        private readonly IOrderService _orderService;
        public SavePurchaseRequestCommandHandler(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public Task<ResultDTO> Handle(SavePurchaseRequestCommand request, CancellationToken cancellationToken)
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

            var response = _orderService.SavePurchaseRequest(purchaseRequestDTO, cancellationToken);

            return response;
        }
    }
}