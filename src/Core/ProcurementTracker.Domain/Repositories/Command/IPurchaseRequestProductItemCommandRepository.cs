using ProcurementTracker.Domain.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Repositories.Command
{
    public interface IPurchaseRequestProductItemCommandRepository : ICommandRepository<PurchaseRequestProductItem>
    {
    }
}
