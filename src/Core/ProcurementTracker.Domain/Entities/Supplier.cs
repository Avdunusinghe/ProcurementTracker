namespace ProcurementTracker.Domain.Entities
{
    public class Supplier : BaseAuditableEntity
    {
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<PurchaseRequest> purchaseRequests { get; set; }
    }
}
