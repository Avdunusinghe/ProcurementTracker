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
        public string ReferenceId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Supplier { get; set; }

        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? DateTime { get; set; }
        public bool IsProceesed { get; set; }
        public string OrderBy { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
