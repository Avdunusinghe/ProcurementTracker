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
    public class UserQueryRepository : QueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(ProcurementTrackerContext context)
           : base(context)
        {

        }

        public User GetUserByEmail(string email)
        {
            try
            {
                var user = Context.Users.FirstOrDefault(x => x.Email.Trim() == email.Trim());

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
