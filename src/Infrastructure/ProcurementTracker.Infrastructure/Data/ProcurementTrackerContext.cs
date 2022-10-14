using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Data
{
    public class ProcurementTrackerContext : DbContext, IProcurementTrackerContext
    {
        public ProcurementTrackerContext()
        {

        }

        public Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RetryOnExceptionAsync(Func<Task> func)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
