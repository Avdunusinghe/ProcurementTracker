using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.OrderDTOs
{
    public class OrderFilterDTO
    {
        public int OrderStatus { get; set; }
        public long Supplier { get; set; }
    }
}
