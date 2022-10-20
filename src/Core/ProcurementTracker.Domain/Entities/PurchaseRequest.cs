namespace ProcurementTracker.Domain.Entities
{
    public class PurchaseRequest : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
        public DateTime RequiredDeliveryDate { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public virtual User StatusChangedBy { get; set; }
       
        public Supplier Supplier { get; set; }
       


    }
}
