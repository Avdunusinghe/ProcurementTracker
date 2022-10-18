using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int NumberOfItems { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
