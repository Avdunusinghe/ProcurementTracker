using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Repositories.Command
{
    public class PurchaseRequestProductItemCommandRepository : CommandRepository<PurchaseRequestProductItem>, IPurchaseRequestProductItemCommandRepository
    {
        public PurchaseRequestProductItemCommandRepository(ProcurementTrackerContext context)
           : base(context)
        {

        }


    }
}
