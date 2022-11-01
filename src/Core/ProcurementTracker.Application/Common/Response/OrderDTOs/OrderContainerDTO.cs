using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.OrderDTOs
{
    public class OrderContainerDTO
    {
        public OrderContainerDTO()
        {
            OrderItems = new List<OrderItemDTO>();
        }
        public long Id { get; set; }
        public string ReferenceId { get; set; }
        public decimal TotalPrice { get; set; }
        public string SupplierName { get; set; }
        public string OrderStatusResult { get; set; }
        public long SupplierId { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool IsProceesed { get; set; }
        public string? OrderByName { get; set; }
        public string? LastModifiedByName { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
