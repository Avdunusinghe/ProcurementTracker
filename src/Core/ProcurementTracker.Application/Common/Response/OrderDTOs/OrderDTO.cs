using ProcurementTracker.Application.Common.Response.OrderItemDTOs;
using ProcurementTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.OrderDTOs
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderItems = new List<OrderItemDTO>();
        }
        public decimal TotalPrice { get; set; }
        public long SupplierId { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool IsProceesed { get; set; }
        public string OrderBy { get; set; }
        public  List<OrderItemDTO> OrderItems { get; set; }
    }
}

