using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Repositories.Query
{
    public class PurchaseRequestProductItemQueryRepository : QueryRepository<PurchaseRequestProductItem>, IPurchaseRequestProductItemQueryRepository
    {
        public PurchaseRequestProductItemQueryRepository(ProcurementTrackerContext context)
           : base(context)
        {

        }

        public PurchaseRequestProductItem GetUserByPurchaseRequestId(long id)
        {
            try
            {
                var purchaseRequestProductItem = Context.PurchaseRequestProductItems.FirstOrDefault(x=>x.PurchaseRequestId == id);

                return purchaseRequestProductItem;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
