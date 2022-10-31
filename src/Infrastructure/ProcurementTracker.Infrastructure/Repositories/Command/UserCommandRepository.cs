using ProcurementTracker.Domain.Entities;
using ProcurementTracker.Domain.Repositories.Command;
using ProcurementTracker.Infrastructure.Data;
using ProcurementTracker.Infrastructure.Repositories.Command.Base;

namespace ProcurementTracker.Infrastructure.Repositories.Command
{
    public class UserCommandRepository : CommandRepository<User>, IUserCommandRepository
    {
        public UserCommandRepository(ProcurementTrackerContext context) 
            : base(context)
        {

        }
    }
}
