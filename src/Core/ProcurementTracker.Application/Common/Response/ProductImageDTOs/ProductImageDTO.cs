using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.ProductImageDTOs
{
    public class ProductImageDTO
    {
        public long Id { get; set; }
        public string Attachment { get; set; }
        public string AttachmentName { get; set; }
    }
}
