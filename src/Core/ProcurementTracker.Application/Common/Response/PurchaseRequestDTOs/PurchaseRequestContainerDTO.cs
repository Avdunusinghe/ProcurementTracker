using ProcurementTracker.Domain.Enums;

namespace ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs
{
    public class PurchaseRequestContainerDTO
    {
        public PurchaseRequestContainerDTO()
        {
            PurchaseRequestProductItems = new List<PurchaseRequestProductItemDTO>();
        }

        public long Id { get; set; }
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
        public DateTime RequiredDeliveryDate { get; set; }
        public string Description { get; set; }
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Decimal TotalPrice { get; set; }
        public string StatusChangedByName { get; set; }
        public DateTime CreatedDate { get; set; }


        public List<PurchaseRequestProductItemDTO> PurchaseRequestProductItems { get; set; }
    }
}
