using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Domain.Repositories.Query.Base;
using ProcurementTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly ProcurementTrackerContext Context;
        private DbSet<T> _entities;

        public QueryRepository(ProcurementTrackerContext context)
        {
            this.Context = context;
            this._entities = context.Set<T>();
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _entities.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<T> GetById(long id, CancellationToken cancellationToken)
        {
            var result = await _entities.FirstOrDefaultAsync(x => EF.Property<long>(x, "Id") == id, cancellationToken: cancellationToken);
            return result;
        }
    }
}
