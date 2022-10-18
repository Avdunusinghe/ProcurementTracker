namespace ProcurementTracker.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        

    }
}
