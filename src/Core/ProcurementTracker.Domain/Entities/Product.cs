namespace ProcurementTracker.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
       
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<PurchaseRequestProductItem> PurchaseRequestProductItems { get; set; }

    }
}
