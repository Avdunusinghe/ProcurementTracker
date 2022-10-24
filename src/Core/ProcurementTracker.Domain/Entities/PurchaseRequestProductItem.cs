using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class PurchaseRequestProductItem : BaseEntity
    {
        public long ProductId { get; set; }
        public long PurchaseRequestId { get; set; }

        public PurchaseRequest PurchaseRequest { get; set; }

    }
}
