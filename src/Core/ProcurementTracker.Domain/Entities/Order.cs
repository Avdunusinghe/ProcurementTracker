namespace ProcurementTracker.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public string ReferenceId { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? DateTime { get; set; }
        public bool IsProceesed { get; set; }

        public long OrderByUserId { get; set; }
        public virtual User OrderBy { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
