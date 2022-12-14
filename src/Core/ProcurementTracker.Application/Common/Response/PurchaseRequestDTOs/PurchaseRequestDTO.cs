using ProcurementTracker.Domain.Enums;

namespace ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs
{
    public class PurchaseRequestDTO
    {
        public PurchaseRequestDTO()
        {
            PurchaseRequestProductItems = new List<PurchaseRequestProductItemDTO>();
        }

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

    public class PurchaseRequestProductItemDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int NumberOfItem { get; set; }
        public long PurchaseRequestId { get; set; }
    }

}
