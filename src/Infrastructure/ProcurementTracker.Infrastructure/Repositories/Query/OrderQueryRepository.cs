using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Query;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Query.Base;

namespace ProcurementTracker.Infrastructure.Repositories.Query
{
    public class OrderQueryRepository : QueryRepository<Order>, IOrderQueryRepository
    {
        public OrderQueryRepository(ProcurementTrackerContext context)
           : base(context)
        {

        }

        public IQueryable<Order> GetAllOrdersFormAsync()
        {
            var query = Context.Orders;

            return query;
        }
    }
}
