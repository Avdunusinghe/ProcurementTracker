using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Command.Base;

namespace ProcurementTracker.Infrastructure.Repositories.Command
{
    public class OrderCommandRepository : CommandRepository<Order>,IOrderCommandRepository
    {
        public OrderCommandRepository(ProcurementTrackerContext context)
            : base(context)
        {

        }
    }
}
