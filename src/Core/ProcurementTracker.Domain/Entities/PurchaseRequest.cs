namespace ProcurementTracker.Domain.Entities
{
    public class PurchaseRequest : BaseAuditableEntity
    {
       
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
        public DateTime RequiredDeliveryDate { get; set; }
        public string Description { get; set; }
        public long SupplierId { get; set; }
        public Decimal TotalPrice { get; set; }


        public virtual User StatusChangedBy { get; set; }
        public virtual Supplier Supplier { get; set; }
       

        public virtual ICollection<PurchaseRequestProductItem> PurchaseRequestProductItems { get; set; }



    }
}
