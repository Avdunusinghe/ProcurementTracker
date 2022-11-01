namespace ProcurementTracker.Application.Common.Response.OrderItemDTOs
{
    public class OrderItemDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public int NumberOfItems { get; set; }
        public string ProductName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPriceProduct { get; set; }

    }
}
