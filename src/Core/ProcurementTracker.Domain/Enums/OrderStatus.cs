using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Enums
{
    public enum OrderStatus 
    {
        Pending = 1,
        Approved = 2,
        Declined = 3,
        Placed = 4,
    }
}
