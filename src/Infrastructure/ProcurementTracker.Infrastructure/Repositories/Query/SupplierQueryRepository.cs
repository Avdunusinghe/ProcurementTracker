using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Query.Base;

namespace ProcurementTracker.Infrastructure.Repositories.Query
{
    public class SupplierQueryRepository : QueryRepository<Supplier>, ISupplierQueryRepository
    {
        public SupplierQueryRepository(ProcurementTrackerContext context)
           : base(context)
        {

        }
    }
}
