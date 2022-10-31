using ProcurementTracker.Domain.Repositories.Query.Base;

namespace ProcurementTracker.Domain.Repositories.Query
{
    public interface IOrderQueryRepository : IQueryRepository<Order>
    {
        IQueryable<Order> GetAllOrdersFormAsync();
    }
}
