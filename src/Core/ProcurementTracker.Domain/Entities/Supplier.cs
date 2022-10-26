namespace ProcurementTracker.Domain.Entities
{
    public class Supplier : BaseAuditableEntity
    {
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PurchaseRequest> purchaseRequests { get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}
