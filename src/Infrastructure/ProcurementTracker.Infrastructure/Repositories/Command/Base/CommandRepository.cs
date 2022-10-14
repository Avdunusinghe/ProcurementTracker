using Microsoft.EntityFrameworkCore;
using ProcurementTracker.Domain.Repositories.Command.Base;
using ProcurementTracker.Infrastructure.Data;

namespace ProcurementTracker.Infrastructure.Repositories.Command.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly ProcurementTrackerContext Context;

        public CommandRepository(ProcurementTrackerContext context)
        {
            this.Context = context;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await Context.Set<T>().AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
