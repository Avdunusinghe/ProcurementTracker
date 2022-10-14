using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementTracker.Domain.Repositories.Query.Base
{
    public interface IQueryRepository<T> where T : class
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<T> GetById(long id, CancellationToken cancellationToken);
    }
}
