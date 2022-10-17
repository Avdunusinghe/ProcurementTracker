using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Entities
{
    public class ProductImages : BaseEntity
    {

        public int ProductId { get; set; }
        public string Attachment { get; set; }
        public string AttachementName { get; set; }

        public virtual Product Product { get; set; }
    }
}
