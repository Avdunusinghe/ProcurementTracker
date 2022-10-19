using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string Attachment { get; set; }
        public string AttachementName { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
