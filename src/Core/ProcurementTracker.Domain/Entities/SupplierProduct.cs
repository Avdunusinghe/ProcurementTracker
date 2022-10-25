using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class SupplierProduct : BaseEntity
    {
        public long ProductId { get; set; }
        public long SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }
    }
}
