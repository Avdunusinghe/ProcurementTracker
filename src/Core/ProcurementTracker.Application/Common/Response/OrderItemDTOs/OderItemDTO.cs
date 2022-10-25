using ProcurementTracker.Application.Common.Response.ProductImageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.OrderItemDTOs
{
    public class OderItemDTO
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public long NumberOfItems { get; set; }

        public ProductImageDTO? ProductImage { get; set; }
    }
}
