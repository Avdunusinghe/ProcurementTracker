using ProcurementTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Application.Common.Response.PurchaseRequestDTOs
{
    public class PurchaseRequestFilterDTO
    {
        public PurchaseRequestStatus PurchaseRequestStatus { get; set; }
    }
}
